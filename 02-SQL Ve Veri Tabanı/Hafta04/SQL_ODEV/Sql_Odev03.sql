USE master
GO

DROP DATABASE IF EXISTS SchoolDb
GO

CREATE DATABASE SchoolDb
GO

Use SchoolDb
GO

CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	BirthDate Date NOT NULL DEFAULT GETDATE(),
	
)
GO

CREATE TABLE Courses(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(50) NOT NULL,
	StudentsId INT NOT NULL,
	FOREIGN KEY(StudentsId) REFERENCES Students(Id),
	Credit INT NOT NULL
	
)
GO

INSERT INTO Students(Name,BirthDate)
VALUES
	('Ömer Seyfettin','1884-03-11'),
	('Hakan Yýlmaz','1992-05-12'),
	('Mahmut Can Turan','1885-09-28')

GO

INSERT INTO Courses(Title,StudentsId,Credit)
VALUES
('Backend Kursu',3,180),
('Frontend Kursu',1,120),
('Yapay Zeka Kursu',1,100),
('Mobil Geliþtirme Kursu',2,70),
('Muhsaebe Kursu',3,65),
('Yazýlým Kursu',2,200)

GO