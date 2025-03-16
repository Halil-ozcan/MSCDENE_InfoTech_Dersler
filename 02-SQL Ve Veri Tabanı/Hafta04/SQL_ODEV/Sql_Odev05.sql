USE master
GO

DROP DATABASE IF EXISTS CinemaDb
GO

CREATE DATABASE CinemaDb
GO

Use CinemaDb
GO

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	
)
GO

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(100) NOT NULL,
	GenerId INT NOT NULL,
	FOREIGN KEY(GenerId) REFERENCES Genres(Id),
	RelaseYear INT NOT NULL
	
)
GO

INSERT INTO Genres(Name)
VALUES
	('Macera'),
	('Aksiyon'),
	('Komedi')

GO

INSERT INTO Movies(Title,GenerId,RelaseYear)
VALUES
('Fetih 1453',2,2012),
('The Lost City',1,2022),
('Fast X',2,2023),
('Indiana Jones and the Dial of Destiny',1,2023),
('Free Guy',3,2021),
('Palm Springs',3,2020)

GO