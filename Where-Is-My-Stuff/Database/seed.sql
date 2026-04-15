INSERT INTO [dbo].[tbl_categories] (category_name) 
VALUES ('Buty'), ('Górskie'), ('Narciarskie'), ('Ksi¹¿ki');
GO

INSERT INTO [dbo].[tbl_owners] (owner_name)
VALUES ('Ania'), ('Cyprian');
GO

INSERT INTO [dbo].[tbl_location_type] (location_type_name)
VALUES ('Pomieszczenie'), ('Szafka'), ('Pude³ko');
GO

INSERT INTO [dbo].[tbl_operation_type] (operation_type_name)
VALUES ('Delete'), ('Insert'), ('Update'), ('Restore');
GO

INSERT INTO [dbo].[tbl_locations] (parent_id, location_type_id, location_name) VALUES
(NULL, 1, 'Piwnica'),
(1, 2, 'Szafka bia³a'),
(2, 3, 'Pude³ko buty'),
(NULL, 1, 'Salon'),
(4, 2, 'Rega³'),
(4, 2, 'Szafa z lustrem'),
(6, 3, 'Pude³ko ubrania');
GO

INSERT INTO [dbo].[tbl_items] (location_id, category_id, owner_id, item_name, item_description) VALUES 
(3, 1, 1, 'Szpilki ró¿owe', NULL),
(3, 1, 1, 'Kozaki', NULL),
(3, 1, 1, 'Kowbojki', NULL),
(1, 3, 2, 'Narty', 'Granatowe Salomony w czerwonym pokrowcu'),
(2, 2, 2, 'Œpiwór', '¯ó³ty worek'),
(5, 4, 1, 'Seria Harry Potter', NULL),
(6, 2, 2, 'Spodnie górskie', NULL);
GO

INSERT INTO [dbo].[tbl_logs] (operation_type_id, log_message, tbl_name, old_value, new_value, can_undo) VALUES 
(2, 'Za³adowanie bazy danych', 'Database', NULL, NULL, 0);
GO
