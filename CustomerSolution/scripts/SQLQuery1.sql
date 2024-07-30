USE DB_CDB_MANAGEMENT

drop table Product
drop table Client
drop table ProductClient

-- Tabela para armazenar os produtos
CREATE TABLE Product (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Value DECIMAL(18, 2) NOT NULL,
    CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
    ExpirationDate DATETIME NOT NULL,
    InterestRate DECIMAL(5, 2) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1
);

CREATE TABLE Client (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    BirthDate DATE NOT NULL,
    CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
    IsActive BIT NOT NULL DEFAULT 1
);

CREATE TABLE ProductClient (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    ClientId INT NOT NULL,
    PurchaseDate DATETIME NOT NULL DEFAULT GETDATE(),
    PurchaseValue DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES Product(Id) ON DELETE CASCADE,
    FOREIGN KEY (ClientId) REFERENCES Client(Id) ON DELETE CASCADE
);



-- Dados de exemplo
INSERT INTO Product (Name, Description, Value, CreationDate, ExpirationDate, InterestRate, IsActive)
VALUES
('CDB Fixed Income', 'Fixed income CDB with monthly interest', 1000.00, GETDATE(), '2025-07-27', 5.50, 1),
('CDB Variable Income', 'Variable income CDB with annual interest', 2000.00, GETDATE(), '2026-07-27', 6.25, 1),
('CDB Short Term', 'Short term CDB with quarterly interest', 1500.00, GETDATE(), '2024-12-27', 4.75, 1);

INSERT INTO Client (FirstName, LastName, Email, BirthDate, CreationDate, IsActive)
VALUES
('John', 'Doe', 'john.doe@example.com', '1985-04-12', GETDATE(), 1),
('Jane', 'Smith', 'jane.smith@example.com', '1990-06-25', GETDATE(), 1),
('Robert', 'Johnson', 'robert.johnson@example.com', '1978-11-30', GETDATE(), 1);

INSERT INTO ProductClient (ProductId, ClientId, PurchaseDate, PurchaseValue)
VALUES
(1, 1, GETDATE(), 1000.00),
(2, 2, GETDATE(), 2000.00),
(3, 3, GETDATE(), 1500.00);

SELECT Id, Name, Description, Value, CreationDate, ExpirationDate, InterestRate, IsActive
FROM Product;

SELECT Id, FirstName, LastName, Email, BirthDate, CreationDate, IsActive
FROM Client;

SELECT Id, ProductId, ClientId, PurchaseDate, PurchaseValue
FROM ProductClient;

SELECT 
    pc.Id AS ProductClientId,
    p.Id AS ProductId,
    p.Name AS ProductName,
    p.Description AS ProductDescription,
    p.Value AS ProductValue,
    p.CreationDate AS ProductCreationDate,
    p.ExpirationDate AS ProductExpirationDate,
    p.InterestRate AS ProductInterestRate,
    p.IsActive AS ProductIsActive,
    c.Id AS ClientId,
    c.FirstName AS ClientFirstName,
    c.LastName AS ClientLastName,
    c.Email AS ClientEmail,
    c.BirthDate AS ClientBirthDate,
    c.CreationDate AS ClientCreationDate,
    c.IsActive AS ClientIsActive,
    pc.PurchaseDate,
    pc.PurchaseValue
FROM 
    ProductClient pc
JOIN 
    Product p ON pc.ProductId = p.Id
JOIN 
    Client c ON pc.ClientId = c.Id;

ALTER TABLE ProductClient
DROP CONSTRAINT FK_ProductClient_ClientId;