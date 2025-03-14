USE master
GO

DROP DATABASE IF EXISTS BookDb /* Bu varsa sil demek */
GO

CREATE DATABASE BookDb
GO

USE BookDb /* bu database aktif hale getir diyor.*/
GO

CREATE TABLE Categories(
		Id INT PRIMARY KEY IDENTITY(1,1),
		Name VARCHAR(50) NOT NULL,
		Description VARCHAR(MAX) NOT NULL,
		IsActive BIT NOT NULL DEFAULT 1,
		CreatedAt DATE NOT NULL DEFAULT GETDATE()
		
)
GO

INSERT INTO Categories(Name,Description,IsActive) 
VALUES
	('Macera','Macera kitaplar�',1),
	('Roman','D�nya Edebiyat�',1),
	('Akademik','Veri Yap�lar�',0)
GO

CREATE TABLE Books(
	Id INT  PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	Description VARCHAR(MAX) NOT NULL,
	Author VARCHAR(100) NOT NULL,
	Price DECIMAL(10,2) NOT NULL,
	IsActive BIT NOT NULL DEFAULT 1,
	CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	CategoryId INT NOT NULL,
	FOREIGN KEY(CategoryId) REFERENCES Categories(Id) /*FOREIGN KEY demek burdaki bir colonun diger bir tablo ile ili�kisi var demek anlam�na geliyor*/
)
GO

INSERT INTO Books(Name,Description,Author,Price,CategoryId)
VALUES
	('Cesur Yeni D�nya','A��klama1','Auxley',248,1),
	('1984','A��klama2','Bob',198,1),
	('�al�nan Dikkat','A��klama3','Ali',410,2)
GO