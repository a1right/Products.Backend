CREATE DATABASE TestDB;
ALTER DATABASE TestDB COLLATE Cyrillic_General_100_CI_AS_KS_WS_SC; 

GO

USE TestDB;

GO

CREATE TABLE Product (
Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
Name NVARCHAR(255) NOT NULL UNIQUE,
Description NVARCHAR(MAX)
);

GO

CREATE NONCLUSTERED INDEX IX_Product_ProductName
ON Product(Name);

GO

CREATE TABLE ProductVersion (
Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
ProductID UNIQUEIDENTIFIER NOT NULL,
Name NVARCHAR(255) NOT NULL,
Description NVARCHAR(MAX),
CreatingDate DATE NOT NULL DEFAULT GETDATE(),
--Предметная область неизвестна поэтому максимальные габариты 10м, точность 0.01мм
Width DECIMAL(7,2) NOT NULL,
Height DECIMAL(7,2) NOT NULL,
Length DECIMAL(7,2) NOT NULL,
FOREIGN KEY (ProductID) REFERENCES Product(Id) ON DELETE CASCADE
--С индексами пока не разобрался :)
);

GO

CREATE NONCLUSTERED INDEX IX_ProductVersion_VersionName
ON ProductVersion(Name);

GO

CREATE NONCLUSTERED INDEX IX_ProductVersion_CreatingDate
ON ProductVersion(CreatingDate);

GO

CREATE NONCLUSTERED INDEX IX_ProductVersion_VersionWidth
ON ProductVersion(Width);

GO

CREATE NONCLUSTERED INDEX IX_ProductVersion_VersionHeight
ON ProductVersion(Height);

GO

CREATE NONCLUSTERED INDEX IX_ProductVersion_VersionLength
ON ProductVersion(Length);

GO

CREATE TABLE EventLog(
Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
EventDate DATE NOT NULL DEFAULT GETDATE(),
Description NVARCHAR(MAX)
);

GO

CREATE NONCLUSTERED INDEX IX_EventLog_EventDate
ON EventLog(EventDate);

GO

CREATE TRIGGER ProductAddOrModifyLogger ON Product
AFTER INSERT, UPDATE
AS
INSERT INTO EventLog(ID, EventDate, Description) VALUES(
NEWID(),
GETDATE(),
CONCAT(CONCAT(CONCAT((SELECT Id FROM inserted), ' with name '), (SELECT Name FROM inserted)), ' was inserdet/modified.')
);

GO

CREATE TRIGGER ProductDeleteLogger ON Product
AFTER DELETE
AS
INSERT INTO EventLog(ID, EventDate, Description) VALUES(
NEWID(),
GETDATE(),
CONCAT(CONCAT(CONCAT((SELECT Id FROM deleted), ' with name '), (SELECT Name FROM inserted)), ' was deleted.')
);

GO

CREATE TRIGGER ProductVersionAddOrModifyLogger ON ProductVersion
AFTER INSERT, UPDATE
AS
INSERT INTO EventLog(ID, EventDate, Description) VALUES(
NEWID(),
GETDATE(),
CONCAT(CONCAT(CONCAT((SELECT Id FROM inserted), ' with name '), (SELECT Name FROM inserted)), ' was inserdet/modified.')
);

GO

CREATE TRIGGER ProductVersionDeleteLogger ON ProductVersion
AFTER DELETE
AS
INSERT INTO EventLog(ID, EventDate, Description) VALUES(
NEWID(),
GETDATE(),
CONCAT(CONCAT(CONCAT((SELECT Id FROM deleted), ' with name '), (SELECT Name FROM inserted)), ' was deleted.')
);

GO
CREATE PROCEDURE SearchByProductName (@namePartial NVARCHAR(255))
AS
SELECT ProductVersion.Id, Product.Name, ProductVersion.Name as 'ProductVersion.Name', ProductVersion.Width, ProductVersion.Length, ProductVersion.Height
FROM Product
JOIN ProductVersion ON ProductVersion.ProductID = Product.Id
WHERE Product.Name LIKE '%' + @namePartial + '%';

GO

CREATE PROCEDURE SearchByProductVersionName (@namePartial NVARCHAR(255))
AS
SELECT ProductVersion.Id, Product.Name as 'Product.Name', ProductVersion.Name, ProductVersion.Width, ProductVersion.Length, ProductVersion.Height
FROM ProductVersion
JOIN Product ON ProductVersion.ProductID = Product.Id
WHERE ProductVersion.Name LIKE '%' + @namePartial + '%';

GO

CREATE PROCEDURE SearchByMinSize (@minSize DECIMAL(7,2))
AS
SELECT ProductVersion.Id, Product.Name, ProductVersion.Name, ProductVersion.Width, ProductVersion.Length, ProductVersion.Height
FROM Product
JOIN ProductVersion ON ProductVersion.ProductID = Product.Id
WHERE ProductVersion.Height >= @minSize OR ProductVersion.Length >= @minSize OR ProductVersion.Height >= @minSize;

GO

CREATE PROCEDURE SearchByMaxSize (@maxSize DECIMAL(7,2))
AS
SELECT ProductVersion.Id, Product.Name, ProductVersion.Name, ProductVersion.Width, ProductVersion.Length, ProductVersion.Height
FROM Product
JOIN ProductVersion ON ProductVersion.ProductID = Product.Id
WHERE ProductVersion.Height <= @maxSize OR ProductVersion.Length <= @maxSize OR ProductVersion.Height <= @maxSize;

--Initial data seed
GO

INSERT INTO Product(Id,Name, Description) VALUES(
'049F1AB1-5FC5-46B8-A9AC-464B7E6A1265',
'Стол деревяный',
'Описание деревяного стола'
);

GO

INSERT INTO Product(Id,Name, Description) VALUES(
'882998DB-5A8C-4052-B278-9F6DF29A48F4',
'Стол стальной',
'Описание стального стола'
);

GO

INSERT INTO Product(Id,Name, Description) VALUES(
'ECDDE884-9224-4C84-9CFA-E8AE71DB23D0',
'Стол пластиковый',
'Описание пластикового стола'
);
--Initial ProductVersion
--Wooden Tables

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'049F1AB1-5FC5-46B8-A9AC-464B7E6A1265',
'Стол деревяный "Сказка"',
'Этот стол перенесёт вас в сказку!',
600,
500,
800
);

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'049F1AB1-5FC5-46B8-A9AC-464B7E6A1265',
'Стол деревяный "Фантазия"',
'Описание стола Фантазия',
400,
700,
1200
);

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'049F1AB1-5FC5-46B8-A9AC-464B7E6A1265',
'Стол деревяный "УхТЫ!"',
'Этот стол перенесёт вас в УхТы!',
600,
400,
200
);

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'049F1AB1-5FC5-46B8-A9AC-464B7E6A1265',
'Стол деревяный "Буратино"',
'Этот стол перенесёт вас в сказку!',
600,
500,
800
);

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'049F1AB1-5FC5-46B8-A9AC-464B7E6A1265',
'Стол деревяный "Сказка-2"',
'Этот стол перенесёт вас в сказку-2!',
600,
500,
800
);
-- Steel Tables

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'882998DB-5A8C-4052-B278-9F6DF29A48F4',
'Стол стальной "Сказка"',
'Этот стол перенесёт вас в сказку!',
600,
500,
800
);

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'882998DB-5A8C-4052-B278-9F6DF29A48F4',
'Стол стальной "Фантазия"',
'Описание стола Фантазия',
400,
700,
1200
);

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'882998DB-5A8C-4052-B278-9F6DF29A48F4',
'Стол стальной "УхТЫ!"',
'Этот стол перенесёт вас в УхТы!',
600,
400,
200
);

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'882998DB-5A8C-4052-B278-9F6DF29A48F4',
'Стол стальной "Буратино"',
'Этот стол перенесёт вас в сказку!',
600,
500,
800
);

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'882998DB-5A8C-4052-B278-9F6DF29A48F4',
'Стол стальной "Сказка-2"',
'Этот стол перенесёт вас в сказку-2!',
600,
500,
800
);
--Plastic Tables

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'ECDDE884-9224-4C84-9CFA-E8AE71DB23D0',
'Стол пластиковый "Сказка"',
'Этот стол перенесёт вас в сказку!',
600,
500,
800
);

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'ECDDE884-9224-4C84-9CFA-E8AE71DB23D0',
'Стол пластиковый "Фантазия"',
'Описание стола Фантазия',
400,
700,
1200
);

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'ECDDE884-9224-4C84-9CFA-E8AE71DB23D0',
'Стол пластиковый "УхТЫ!"',
'Этот стол перенесёт вас в УхТы!',
600,
400,
200
);

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'ECDDE884-9224-4C84-9CFA-E8AE71DB23D0',
'Стол пластиковый "Буратино"',
'Этот стол перенесёт вас в сказку!',
600,
500,
800
);

GO

INSERT INTO ProductVersion(Id, ProductID, Name, Description, Width, Height, Length) VALUES(
NEWID(),
'ECDDE884-9224-4C84-9CFA-E8AE71DB23D0',
'Стол пластиковый "Сказка-2"',
'Этот стол перенесёт вас в сказку-2!',
600,
500,
800
);