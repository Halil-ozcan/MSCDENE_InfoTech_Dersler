USE master
GO

DROP DATABASE IF EXISTS SalesDb
GO

CREATE DATABASE SalesDb
GO

Use SalesDb
GO

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	Email  VARCHAR(50) NOT NULL,
	
)
GO

CREATE TABLE Orders(
	Id INT PRIMARY KEY IDENTITY(1,1),
	OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
	CustomerId INT NOT NULL,
	FOREIGN KEY(CustomerId) REFERENCES Customers(Id),
	TotalAmount INT NOT NULL
	
)
GO

INSERT INTO Customers(Name,Email)
VALUES
	('Ömer Seyfettin','omer@gmail.com'),
	('Halide Edib AdýVar','halide@gmail.com'),
	('Reþat Nuri Güntekin','resat@gmail.com')

GO

INSERT INTO Orders(OrderDate,CustomerId,TotalAmount)
VALUES
(03-05-2025,2,48000),
(05-07-2024,2,35000),
(08-01-2025,1,25000),
(20-06-2023,1,32000),
(18-08-2024,3,5000),
(04-09-2024,3,3500)

GO