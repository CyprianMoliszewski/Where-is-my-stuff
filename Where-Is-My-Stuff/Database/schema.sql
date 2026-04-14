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