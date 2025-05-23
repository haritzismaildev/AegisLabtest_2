-- = = = = = = = = query create table = = = = = = = = = --
CREATE TABLE DataModel (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nama NVARCHAR(100) NOT NULL,
    Tanggal DATETIME NOT NULL
);
-- = = = = = = = = query create procedure = = = = = = = = --
CREATE PROCEDURE GetData
AS
BEGIN
    SELECT Id, Nama, Tanggal FROM DataModel;
END;
-- = = = = = = = = = = = = = = = = =  query create data dummy untuk test = = = = = = = 
USE AegisLabsDB;

INSERT INTO DataModel (Nama, Tanggal) VALUES 
('Haritz', '2025-05-23'),
('Dimas', '2025-05-22'),
('Nadia', '2025-05-21'),
('Rina', '2025-05-20'),
('Fajar', '2025-05-19');