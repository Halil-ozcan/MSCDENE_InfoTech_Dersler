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
	('Ömer Seyfettin',1882),
	('Halide Edib AdýVar',1884),
	('Reþat Nuri Güntekin',1889)

GO

INSERT INTO Books(Title,AuthorsId,PublishedYear)
VALUES
('Ateþten Gömlek',2,1923),
('Mor Salkýmlý Ev',2,1963),
('Efruz Bey',1,1919),
('Beyaz Lale',1,1938),
('Çalýkuþu',3,1922),
('Yaprak Dökümü',3,1930)

GO