use master
go

if exists (select * from sys.databases where name = 'StockManagementDb')
begin
	alter database StockManagementDb set single_user with rollback immediate
	drop database StockManagementDb
end
go

create database StockManagementDb
go

use StockManagementDb
go

create table Categories(
	Id int primary key identity,
	Name nvarchar(max) not null,
	Description nvarchar(max) not null,
	IsDeleted bit not null default 0,
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null	default getdate()
)
go

create table Suppliers(
	Id int primary key identity,
	Name nvarchar(max) not null,
	ContactName nvarchar(max) not null,
	Email nvarchar(max) not null,
	PhoneNumber nvarchar(max) not null,
	Address nvarchar(max) not null,
	City nvarchar(max) not null,
	Country nvarchar(max) not null,
	IsDeleted bit not null default 0,
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null	default getdate()
)
go

create table Products(
	Id int primary key identity,
	Name nvarchar(max) not null,
	Properties nvarchar(max) not null,
	Price decimal(10,2) not null,
	StockQuantity int not null default 0,
	MinimumStockLevel int not null default 1,
	IsDeleted bit not null default 0,
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null	default getdate(),
	CategoryId int not null,
	SupplierId int not null,
	constraint FK_Products_Category foreign key (CategoryId) references Categories(Id),
	constraint FK_Products_Supplier foreign key (SupplierId) references Suppliers(Id),
	constraint CHK_Products_StockQuaintity check (StockQuantity>=0),
	constraint CHK_Products_MinimumStockLevel check (MinimumStockLevel>=1),
	constraint CHK_Products_Price check (Price>0)
)
go

create table TransactionTypes(
	Id int primary key identity,
	Title nvarchar(max) not null,
	Description nvarchar(max) not null,
	IsDeleted bit not null default 0,
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null	default getdate()
)
go
-- 1  -  Giriþ    - Stok alýmlarý için
-- 2  -  Çýkýþ    - Satýþlar için

create table Transactions(
	Id int primary key identity,
	ProductId int not null,
	TransactionTypeId int not null,
	TransactionDate datetime not null default getdate(),
	Quantity int not null default 1,
	Note nvarchar(max),
	IsDeleted bit not null default 0,
	constraint FK_Transactions_Product foreign key (ProductId) references Products(Id),
	constraint FK_Transactions_TransactionType foreign key(TransactionTypeId) references TransactionTypes(Id),
	constraint CHK_Transactions_Quantity check (Quantity>=1)
)
go

create table Customers(
	Id int primary key identity,
	Name nvarchar(max) not null,
	ContactName nvarchar(max) not null,
	Email nvarchar(max) not null,
	PhoneNumber nvarchar(max) not null,
	Address nvarchar(max) not null,
	City nvarchar(max) not null,
	Country nvarchar(max) not null,
	IsDeleted bit not null default 0,
	CreatedAt datetime not null default getdate(),
	UpdatedAt datetime not null	default getdate()
)
go

create table Sales(
	Id int primary key identity,
	ProductId int not null,
	CustomerId int not null,
	Quantity int not null,
	UnitPrice int not null,
	SaleDate datetime not null default getdate()
)
go

-- Products ile ilgili Index'ler
create nonclustered index IX_Products_CategoryId on Products(CategoryId)
create nonclustered index IX_Products_SupplierId on Products(SupplierId)
--create nonclustered index IX_Products_Name on Products(Name)

-------------------------------------------------
-- ÖRNEK VERÝ GÝRÝÞLERÝ --
-------------------------------------------------
-- Categories
INSERT INTO Categories (Name, Description)
VALUES
	('Elektronik', 'Her türlü elektronik ürünler ve cihazlar'),
	('Ev Eþyalarý', 'Ev dekorasyonu ve ev içi ihtiyaçlar'),
	('Moda', 'Kadýn, erkek ve çocuk giyim ürünleri'),
	('Kitaplar', 'Farklý türlerde kitaplar'),
	('Gýda', 'Temel gýda maddeleri ve ürünleri'),
	('Spor Malzemeleri', 'Fitness ve spor ekipmanlarý'),
	('Müzik Aletleri', 'Müzik enstrümanlarý ve aksesuarlarý'),
	('Bilgisayar & Yazýlým', 'Bilgisayar donaným ve yazýlým ürünleri'),
	('Otomotiv', 'Araç gereç ve otomotiv aksesuarlarý'),
	('Yazýlým ve Teknoloji', 'Teknoloji ve yazýlým çözümleri')
go

-- Suppliers
INSERT INTO Suppliers (Name, ContactName, Email, PhoneNumber, Address, City, Country)
VALUES
	('ABC Elektronik', 'Ahmet Yýlmaz', 'ahmet.yilmaz@abc.com', '555-1234', 'Ýstanbul Cad. No:1', 'Ýstanbul', 'Türkiye'),
	('TeknoBiliþim', 'Ayþe Demir', 'ayse.demir@teknobilisim.com', '555-5678', 'Karaköy Mah. No:23', 'Ýstanbul', 'Türkiye'),
	('Global Supplies', 'Mehmet Kaya', 'mehmet.kaya@globalsupplies.com', '555-8765', 'Çankaya Cad. No:45', 'Ankara', 'Türkiye'),
	('Sunshine Elektronik', 'Elif Çelik', 'elif.celik@sunshine.com', '555-4321', 'Bahçelievler Mah. No:12', 'Ankara', 'Türkiye'),
	('Beyaz Gýda', 'Fatma Aksoy', 'fatma.aksoy@beyazgida.com', '555-2468', 'Beylikdüzü Mah. No:9', 'Ýstanbul', 'Türkiye'),
	('SüperTeknik', 'Ali Vural', 'ali.vural@superteknik.com', '555-1357', 'Bursa Cad. No:78', 'Bursa', 'Türkiye'),
	('Güvenlik Çözümleri', 'Zeynep Arslan', 'zeynep.arslan@guvenlik.com', '555-3692', 'Yeniköy Mah. No:5', 'Ýstanbul', 'Türkiye'),
	('Renkli Ev Eþyalarý', 'Kemal Þahin', 'kemal.sahin@renklieþyalar.com', '555-7531', 'Mecidiyeköy Mah. No:3', 'Ýstanbul', 'Türkiye'),
	('Fiyat Market', 'Murat Savaþ', 'murat.savas@fiyatmarket.com', '555-8642', 'Eskiþehir Cad. No:34', 'Eskiþehir', 'Türkiye'),
	('Nehir Spor', 'Aylin Kaya', 'aylin.kaya@nehirspor.com', '555-9753', 'Aksaray Mah. No:55', 'Ýstanbul', 'Türkiye')
go

-- Products
INSERT INTO Products (Name, Properties, Price, StockQuantity, MinimumStockLevel, CategoryId, SupplierId)
VALUES
	-- Kategori 1 (Elektronik) - 5 ürün
	('Akýllý Telefon', 'Yüksek çözünürlüklü ekran, hýzlý iþlemci', 5000.00, 50, 1, 1, 1),
	('Laptop', 'Intel i7 iþlemci, 16GB RAM, 512GB SSD', 7000.00, 30, 1, 1, 1),
	('Tablet', '10 inç ekran, 64GB depolama', 2000.00, 100, 1, 1, 2),
	('Kulaklýk', 'Noise-cancelling, kablosuz', 500.00, 70, 1, 1, 2),
	('Mikrofon', 'USB baðlantýlý, stüdyo kalitesinde', 800.00, 40, 1, 1, 3),

	-- Kategori 2 (Ev Eþyalarý) - 3 ürün
	('Koltuk Takýmý', 'Modern tasarým, 3 kiþilik', 2500.00, 15, 1, 2, 4),
	('Buzdolabý', 'A+ enerji verimliliði, 350L', 3500.00, 10, 1, 2, 4),
	('Mikrodalga Fýrýn', '900W, dijital kontrol paneli', 700.00, 50, 1, 2, 5),

	-- Kategori 3 (Moda) - 4 ürün
	('Tiþört', 'Pamuklu, rahat kesim', 100.00, 100, 1, 3, 6),
	('Kot Pantolon', 'Slim fit, mavi renk', 200.00, 50, 1, 3, 6),
	('Ceket', 'Derimsi, siyah', 400.00, 20, 1, 3, 7),
	('Gömlek', 'Beyaz, düðmeli, klasik kesim', 150.00, 75, 1, 3, 7),

	-- Kategori 4 (Kitaplar) - 2 ürün
	('Java Programlama', 'Modern yazýlým geliþtirme teknikleri', 150.00, 80, 1, 4, 8),
	('Veritabaný Yönetim Sistemleri', 'SQL ve NoSQL veritabanlarý', 120.00, 60, 1, 4, 9),

	-- Kategori 5 (Gýda) - 3 ürün
	('Peynir', '100% organik, %20 yaðlý', 30.00, 200, 1, 5, 10),
	('Zeytin', 'Kalamata, doðal', 25.00, 150, 1, 5, 10),
	('Zeytinyaðý', 'Soðuk sýkým, organik', 80.00, 90, 1, 5, 9),

	-- Kategori 6 (Spor Malzemeleri) - 4 ürün
	('Dambýl Seti', '4 kg, 6 kg, 8 kg', 250.00, 40, 1, 6, 1),
	('Yoga Matý', 'Kaymaz, 10mm kalýnlýk', 100.00, 100, 1, 6, 2),
	('Koþu Bandý', 'Elektrikli, dijital ekranlý', 1500.00, 10, 1, 6, 2),
	('Spor Ayakkabý', 'Rahat, koþu için uygun', 350.00, 75, 1, 6, 1),

	-- Kategori 7 (Müzik Aletleri) - 2 ürün
	('Gitar', 'Akustik, doðal ahþap', 1500.00, 20, 1, 7, 3),
	('Piyano', 'Digital, 88 tuþ', 3500.00, 5, 1, 7, 4),

	-- Kategori 8 (Bilgisayar & Yazýlým) - 3 ürün
	('Ofis Yazýlýmý', 'Microsoft Office 365', 500.00, 100, 1, 8, 5),
	('Antivirüs Yazýlýmý', 'Yýllýk lisans, Windows uyumlu', 150.00, 200, 1, 8, 6),
	('Web Tasarým Yazýlýmý', 'Adobe Photoshop ve Illustrator', 1200.00, 50, 1, 8,5),

	-- Kategori 9 (Otomotiv) - 3 ürün
	('Oto lastik', 'Hava koþullarýna dayanýklý', 400.00, 50, 1, 9, 7),
	('Araç Yaðlarý', 'Motor ve þanzýman için', 100.00, 100, 1, 9, 8),
	('Otomatik Þanzýman Yaðý', 'Yüksek performanslý', 120.00, 80, 1, 9, 7),

	-- Kategori 10 (Yazýlým ve Teknoloji) - 4 ürün
	('Web Geliþtirme Kursu', 'JavaScript ve React eðitimi', 1200.00, 10, 1, 10, 9),
	('Veritabaný Eðitimi', 'SQL ve NoSQL dersleri', 800.00, 20, 1, 10, 9),
	('Yazýlým Mühendisliði Kitaplarý', 'C#, Python, Java kitaplarý', 200.00, 50, 1, 10, 2),
	('Siber Güvenlik Eðitimi', 'Að güvenliði ve saldýrý öncesi savunma teknikleri', 1000.00, 15, 1, 10, 2)
go

-- TransactionTypes
INSERT INTO TransactionTypes (Title, Description)
VALUES
	('Giriþ', 'Stoklara yeni ürün eklenmesi, satýþtan elde edilen gelirlerin sisteme giriþ yapýlmasý.'),
	('Çýkýþ', 'Stoklardan ürün çýkýþý, satýþ iþlemleri veya ürün iade iþlemleri sonucu çýkan ürünler.')
go

-- Giriþ ve çýkýþ iþlemleri
INSERT INTO Transactions (ProductId, TransactionTypeId, TransactionDate, Quantity, Note)
VALUES
	-- Akýllý Telefon
	(1, 1, DATEADD(MONTH, -1, GETDATE()), 10, 'Yeni ürün eklemesi'),
	(1, 2, DATEADD(MONTH, -2, GETDATE()), 5, 'Satýþ iþlemi'),
	(1, 2, DATEADD(MONTH, -3, GETDATE()), 8, 'Satýþ iþlemi'),
	(1, 1, DATEADD(MONTH, -4, GETDATE()), 15, 'Yeni ürün eklemesi'),
	(1, 2, DATEADD(MONTH, -5, GETDATE()), 6, 'Satýþ iþlemi'),

	-- Laptop
	(2, 1, DATEADD(MONTH, -1, GETDATE()), 7, 'Yeni ürün eklemesi'),
	(2, 2, DATEADD(MONTH, -2, GETDATE()), 10, 'Satýþ iþlemi'),
	(2, 1, DATEADD(MONTH, -3, GETDATE()), 5, 'Yeni ürün eklemesi'),
	(2, 2, DATEADD(MONTH, -4, GETDATE()), 12, 'Satýþ iþlemi'),

	-- Koltuk Takýmý
	(3, 1, DATEADD(MONTH, -2, GETDATE()), 3, 'Yeni ürün eklemesi'),
	(3, 2, DATEADD(MONTH, -3, GETDATE()), 2, 'Satýþ iþlemi'),
	(3, 1, DATEADD(MONTH, -4, GETDATE()), 4, 'Yeni ürün eklemesi'),

	-- Buzdolabý
	(4, 1, DATEADD(MONTH, -1, GETDATE()), 6, 'Yeni ürün eklemesi'),
	(4, 2, DATEADD(MONTH, -2, GETDATE()), 3, 'Satýþ iþlemi'),
	(4, 2, DATEADD(MONTH, -4, GETDATE()), 2, 'Satýþ iþlemi'),

	-- Tiþört
	(5, 1, DATEADD(MONTH, -1, GETDATE()), 20, 'Yeni ürün eklemesi'),
	(5, 2, DATEADD(MONTH, -2, GETDATE()), 25, 'Satýþ iþlemi'),
	(5, 2, DATEADD(MONTH, -3, GETDATE()), 30, 'Satýþ iþlemi'),
	(5, 1, DATEADD(MONTH, -5, GETDATE()), 10, 'Yeni ürün eklemesi'),

	-- Kot Pantolon
	(6, 1, DATEADD(MONTH, -1, GETDATE()), 15, 'Yeni ürün eklemesi'),
	(6, 2, DATEADD(MONTH, -2, GETDATE()), 10, 'Satýþ iþlemi'),
	(6, 2, DATEADD(MONTH, -3, GETDATE()), 12, 'Satýþ iþlemi'),

	-- Java Programlama
	(7, 1, DATEADD(MONTH, -2, GETDATE()), 10, 'Yeni kitap eklemesi'),
	(7, 2, DATEADD(MONTH, -4, GETDATE()), 5, 'Satýþ iþlemi'),

	-- Zeytin
	(8, 1, DATEADD(MONTH, -3, GETDATE()), 50, 'Yeni ürün eklemesi'),
	(8, 2, DATEADD(MONTH, -1, GETDATE()), 40, 'Satýþ iþlemi'),
	(8, 1, DATEADD(MONTH, -2, GETDATE()), 60, 'Yeni ürün eklemesi'),

	-- Dambýl Seti
	(9, 1, DATEADD(MONTH, -3, GETDATE()), 10, 'Yeni ürün eklemesi'),
	(9, 2, DATEADD(MONTH, -2, GETDATE()), 8, 'Satýþ iþlemi'),
	(9, 2, DATEADD(MONTH, -1, GETDATE()), 12, 'Satýþ iþlemi'),

	-- Gitar
	(10, 1, DATEADD(MONTH, -2, GETDATE()), 5, 'Yeni ürün eklemesi'),
	(10, 2, DATEADD(MONTH, -3, GETDATE()), 3, 'Satýþ iþlemi'),
	(10, 2, DATEADD(MONTH, -1, GETDATE()), 4, 'Satýþ iþlemi')

go

-- Customers

INSERT INTO Customers (Name, ContactName, Email, PhoneNumber, Address, City, Country)
VALUES
	('Tech Solutions Ltd.', 'Ali Yýlmaz', 'info@techsolutions.com', '+90 212 123 45 67', 'Tech Street 45, Suite 5', 'Istanbul', 'Turkey'),
	('Fresh Foods', 'Mehmet Kaya', 'contact@freshfoods.com', '+90 212 234 56 78', 'Green Market 12', 'Ankara', 'Turkey'),
	('SuperMart', 'Elif Demir', 'support@supermart.com', '+90 312 345 67 89', 'Super Plaza 3, 2nd Floor', 'Izmir', 'Turkey'),
	('Innovative Systems', 'Murat Çelik', 'sales@innovativesystems.com', '+90 322 456 78 90', 'Innovation Road 88', 'Adana', 'Turkey'),
	('Luxury Furnishings', 'Ayþe Kýlýç', 'contact@luxuryfurnishings.com', '+90 542 567 89 01', 'Elite Homes, 9th Floor', 'Bursa', 'Turkey'),
	('Healthy Eats', 'Zeynep Güler', 'hello@healthyeats.com', '+90 216 678 90 12', 'Organic Market 33', 'Istanbul', 'Turkey'),
	('Global Electronics', 'Emre Þahin', 'info@globalelectronics.com', '+90 312 789 01 23', 'HighTech Building, 4th Floor', 'Izmir', 'Turkey'),
	('Speedy Logistics', 'Can Özdemir', 'support@speedylogistics.com', '+90 533 890 12 34', 'Fast Delivery Road 22', 'Ankara', 'Turkey'),
	('TechnoCare', 'Deniz Öztürk', 'service@technocare.com', '+90 532 234 56 78', 'Healthcare Avenue 8', 'Istanbul', 'Turkey'),
	('Auto Parts World', 'Ahmet Yýldýz', 'info@autopartsworld.com', '+90 212 123 45 67', 'Auto Center 56', 'Istanbul', 'Turkey'),
	('The Art Studio', 'Aylin Kurt', 'art@theartstudio.com', '+90 212 234 56 78', 'Art Street 12', 'Istanbul', 'Turkey'),
	('Classic Books', 'Berkay Arslan', 'sales@classicbooks.com', '+90 538 567 89 01', 'Library Lane 8', 'Bursa', 'Turkey'),
	('Green Energy Co.', 'Cemre Bozkurt', 'info@greenenergy.com', '+90 553 678 90 12', 'Solar Park 7', 'Ankara', 'Turkey'),
	('FreshTech', 'Pelin Kaya', 'support@freshtech.com', '+90 535 234 56 78', 'Tech Tower 4', 'Istanbul', 'Turkey'),
	('MegaConstructions', 'Murat Kucuk', 'contact@megaconstructions.com', '+90 212 345 67 89', 'Construction Avenue 15', 'Istanbul', 'Turkey')
go