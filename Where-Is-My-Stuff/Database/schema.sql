CREATE TABLE [dbo].[tbl_categories] (
    [category_id]   INT          IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [category_name] VARCHAR (50) NOT NULL
);
GO

CREATE TABLE [dbo].[tbl_owners] (
    [owner_id]   INT          IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [owner_name] VARCHAR (50) NOT NULL
);
GO

CREATE TABLE [dbo].[tbl_location_type] (
    [location_type_id]   INT          IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [location_type_name] VARCHAR (50) NOT NULL
);
GO

CREATE TABLE [dbo].[tbl_operation_type] (
    [operation_type_id]   INT          IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [operation_type_name] VARCHAR (50) NOT NULL
);
GO

CREATE TABLE [dbo].[tbl_locations] (
    [location_id]      INT          IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [parent_id]        INT          NULL,
    [location_type_id] INT          NOT NULL,
    [location_name]    VARCHAR (50) NOT NULL,
    [is_active]        BIT          NOT NULL DEFAULT 1,
    [create_date]      DATETIME     NOT NULL DEFAULT GETDATE(),
    [update_date]      DATETIME     NOT NULL DEFAULT GETDATE(),

    CONSTRAINT [FK_tbl_locations_tbl_locations] FOREIGN KEY ([parent_id]) 
        REFERENCES [dbo].[tbl_locations] ([location_id]),
    CONSTRAINT [FK_tbl_locations_tbl_location_type] FOREIGN KEY ([location_type_id]) 
        REFERENCES [dbo].[tbl_location_type] ([location_type_id])
);
GO

CREATE TRIGGER [dbo].[trg_locations_UpdateDate]
ON [dbo].[tbl_locations]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [dbo].[tbl_locations]
    SET [update_date] = GETDATE()
    FROM [dbo].[tbl_locations]
    INNER JOIN inserted ON [dbo].[tbl_locations].[location_id] = [inserted].[location_id];
END;
GO

CREATE TABLE [dbo].[tbl_items] (
    [item_id]          INT           IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [location_id]      INT           NOT NULL,
    [category_id]      INT           NOT NULL,
    [owner_id]         INT           NOT NULL,
    [item_name]        VARCHAR (50)  NOT NULL,
    [item_description] VARCHAR (255) NULL,
    [is_active]        BIT           NOT NULL DEFAULT 1,
    [create_date]      DATETIME      NOT NULL DEFAULT GETDATE(),
    [update_date]      DATETIME      NOT NULL DEFAULT GETDATE(),

    CONSTRAINT [FK_tbl_items_tbl_locations] FOREIGN KEY ([location_id]) 
        REFERENCES [dbo].[tbl_locations] ([location_id]),
    CONSTRAINT [FK_tbl_items_tbl_categories] FOREIGN KEY ([category_id]) 
        REFERENCES [dbo].[tbl_categories] ([category_id]),
    CONSTRAINT [FK_tbl_items_tbl_owners] FOREIGN KEY ([owner_id]) 
        REFERENCES [dbo].[tbl_owners] ([owner_id])
);
GO

CREATE TRIGGER [dbo].[trg_items_UpdateDate]
ON [dbo].[tbl_items]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [dbo].[tbl_items]
    SET [update_date] = GETDATE()
    FROM [dbo].[tbl_items]
    INNER JOIN inserted ON [dbo].[tbl_items].[item_id] = [inserted].[item_id];
END;
GO

CREATE TABLE [dbo].[tbl_logs] (
    [log_id]            INT            IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [operation_type_id] INT            NOT NULL,
    [log_date]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [log_message]       VARCHAR (255)  NOT NULL,
    [tbl_name]          VARCHAR (50)   NOT NULL,
    [old_value]         NVARCHAR (MAX) NULL,
    [new_value]         NVARCHAR (MAX) NULL,
    [can_undo]          BIT            NOT NULL DEFAULT 1,

    CONSTRAINT [FK_tbl_logs_tbl_operation_type] FOREIGN KEY ([operation_type_id]) 
        REFERENCES [dbo].[tbl_operation_type] ([operation_type_id])
);
GO

-- 1. TRIGGER DLA PRZEDMIOTÓW
CREATE TRIGGER [dbo].[trg_items_logs]
ON [dbo].[tbl_items]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF TRIGGER_NESTLEVEL() > 1 RETURN;
    IF CAST(SESSION_CONTEXT(N'IsUndo') AS INT) = 1 RETURN;

    INSERT INTO [dbo].[tbl_logs] (
        [operation_type_id], 
        [log_message], 
        [tbl_name], 
        [old_value], 
        [new_value]
    )
    SELECT
        CASE 
            WHEN d.item_id IS NULL THEN 2 -- INSERT
            WHEN i.item_id IS NULL THEN 1 -- DELETE 
            ELSE 3                        -- UPDATE
        END,
        CASE 
            WHEN d.item_id IS NULL THEN CONCAT('Dodano przedmiot: ''', i.item_name, '''')
            WHEN i.item_id IS NULL THEN CONCAT('Usuniêto przedmiot: ''', d.item_name, '''')
            ELSE 
                CASE 
                    WHEN d.item_name <> i.item_name THEN CONCAT('Zmieniono nazwê przedmiotu z ''', d.item_name, ''' na ''', i.item_name, '''')
                    ELSE CONCAT('Edytowano w³aœciwoœci przedmiotu: ''', i.item_name, '''')
                END
        END,
        'tbl_items',
        (SELECT * FROM deleted d2 WHERE d2.item_id = COALESCE(i.item_id, d.item_id) FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER),
        (SELECT * FROM inserted i2 WHERE i2.item_id = COALESCE(i.item_id, d.item_id) FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER)
    FROM 
        inserted i 
    FULL OUTER JOIN deleted d ON i.item_id = d.item_id;
END;
GO

-- 2. TRIGGER DLA LOKALIZACJI
CREATE TRIGGER [dbo].[trg_locations_logs]
ON [dbo].[tbl_locations]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    IF TRIGGER_NESTLEVEL() > 1 RETURN;
    IF CAST(SESSION_CONTEXT(N'IsUndo') AS INT) = 1 RETURN;
    INSERT INTO [dbo].[tbl_logs] (
        [operation_type_id], 
        [log_message], 
        [tbl_name], 
        [old_value], 
        [new_value]
    )
    SELECT
        CASE 
            WHEN d.location_id IS NULL THEN 2
            WHEN i.location_id IS NULL THEN 1
            ELSE 3
        END,
        CASE 
            WHEN d.location_id IS NULL THEN CONCAT('Dodano lokalizacjê: ''', i.location_name, '''')
            WHEN i.location_id IS NULL THEN CONCAT('Usuniêto lokalizacjê: ''', d.location_name, '''')
            ELSE 
                CASE 
                    WHEN d.location_name <> i.location_name THEN CONCAT('Zmieniono nazwê lokalizacji z ''', d.location_name, ''' na ''', i.location_name, '''')
                    ELSE CONCAT('Edytowano w³aœciwoœci lokalizacji: ''', i.location_name, '''')
                END
        END,
        'tbl_locations',
        (SELECT * FROM deleted d2 WHERE d2.location_id = COALESCE(i.location_id, d.location_id) FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER),
        (SELECT * FROM inserted i2 WHERE i2.location_id = COALESCE(i.location_id, d.location_id) FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER)
    FROM 
        inserted i 
    FULL OUTER JOIN deleted d ON i.location_id = d.location_id;
END;
GO

-- 3. TRIGGER DLA W£AŒCICIELI
CREATE TRIGGER [dbo].[trg_owners_logs]
ON [dbo].[tbl_owners]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    IF TRIGGER_NESTLEVEL() > 1 RETURN;
    IF CAST(SESSION_CONTEXT(N'IsUndo') AS INT) = 1 RETURN;
    INSERT INTO [dbo].[tbl_logs] (
        [operation_type_id], 
        [log_message], 
        [tbl_name], 
        [old_value], 
        [new_value]
    )
    SELECT
        CASE 
            WHEN d.owner_id IS NULL THEN 2
            WHEN i.owner_id IS NULL THEN 1
            ELSE 3
        END,
        CASE 
            WHEN d.owner_id IS NULL THEN CONCAT('Dodano w³aœciciela: ''', i.owner_name, '''')
            WHEN i.owner_id IS NULL THEN CONCAT('Usuniêto w³aœciciela: ''', d.owner_name, '''')
            ELSE CONCAT('Zmieniono nazwê w³aœciciela z ''', d.owner_name, ''' na ''', i.owner_name, '''')
        END,
        'tbl_owners',
        (SELECT * FROM deleted d2 WHERE d2.owner_id = COALESCE(i.owner_id, d.owner_id) FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER),
        (SELECT * FROM inserted i2 WHERE i2.owner_id = COALESCE(i.owner_id, d.owner_id) FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER)
    FROM 
        inserted i 
    FULL OUTER JOIN deleted d ON i.owner_id = d.owner_id;
END;
GO

-- 4. TRIGGER DLA KATEGORII
CREATE TRIGGER [dbo].[trg_categories_logs]
ON [dbo].[tbl_categories]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    IF TRIGGER_NESTLEVEL() > 1 RETURN;
    IF CAST(SESSION_CONTEXT(N'IsUndo') AS INT) = 1 RETURN;
    INSERT INTO [dbo].[tbl_logs] (
        [operation_type_id], 
        [log_message], 
        [tbl_name], 
        [old_value], 
        [new_value]
    )
    SELECT
        CASE 
            WHEN d.category_id IS NULL THEN 2
            WHEN i.category_id IS NULL THEN 1
            ELSE 3
        END,
        CASE 
            WHEN d.category_id IS NULL THEN CONCAT('Dodano kategoriê: ''', i.category_name, '''')
            WHEN i.category_id IS NULL THEN CONCAT('Usuniêto kategoriê: ''', d.category_name, '''')
            ELSE CONCAT('Zmieniono nazwê kategorii z ''', d.category_name, ''' na ''', i.category_name, '''')
        END,
        'tbl_categories',
        (SELECT * FROM deleted d2 WHERE d2.category_id = COALESCE(i.category_id, d.category_id) FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER),
        (SELECT * FROM inserted i2 WHERE i2.category_id = COALESCE(i.category_id, d.category_id) FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER)
    FROM 
        inserted i 
    FULL OUTER JOIN deleted d ON i.category_id = d.category_id;
END;
GO