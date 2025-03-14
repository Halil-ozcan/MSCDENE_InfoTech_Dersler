USE master
GO

DROP DATABASE IF EXISTS LibraryDb
GO

CREATE DATABASE LibraryDb
GO

Use LibraryDb
GO

CREATE TABLE Authors(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	BirthYear INT NOT NULL,
	
)
GO

CREATE TABLE Books(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(50) NOT NULL,
	AuthorsId INT NOT NULL,
	FOREIGN KEY(AuthorsId) REFERENCES Authors(Id),
	PublishedYear INT NOT NULL
	
)
GO

INSERT INTO Authors(Name,BirthYear)
VALUES
	('�mer Seyfettin',1882),
	('Halide Edib Ad�Var',1884),
	('Re�at Nuri G�ntekin',1889)

GO

INSERT INTO Books(Title,AuthorsId,PublishedYear)
VALUES
('Ate�ten G�mlek',2,1923),
('Mor Salk�ml� Ev',2,1963),
('Efruz Bey',1,1919),
('Beyaz Lale',1,1938),
('�al�ku�u',3,1922),
('Yaprak D�k�m�',3,1930)

GO