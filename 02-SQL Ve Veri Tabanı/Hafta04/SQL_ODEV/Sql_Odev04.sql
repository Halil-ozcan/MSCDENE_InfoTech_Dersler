USE master
GO

DROP DATABASE  IF EXISTS CompanyDb
GO

CREATE DATABASE CompanyDb
GO

USE CompanyDb


CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	Location VARCHAR(70) NOT NULL,
	
)
GO

CREATE TABLE Employes(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	DepartmanId INT NOT NULL,
	FOREIGN KEY(DepartmanId) REFERENCES Departments(Id),
	Position VARCHAR(60) NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
)
GO

INSERT INTO Departments(Name,Location)
VALUES
	('Yaz�l�m','Gaziantep'),
	('Y�netim','Sivas'),
	('Finans','�stanbul')
GO

INSERT INTO Employes(Name,DepartmanId,Position,Salary)
VALUES
	('Halil �zcan',1,'FullStack',45000),
	('Mehmet Y�lmaz',1,'Backend',30000),
	('Can Kele�',2,'Genel M�d�r',60000),
	('Burhan Terzio�lu',2,'CEO',62000),
	('Mahmut Demir',3,'Muhasebe',30000),
	('Tar�k �amdal',3,'Muhasebe',30000)

GO

