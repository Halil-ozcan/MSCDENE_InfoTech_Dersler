--Tüm ürünlerin adlarýný ve birim fiyatlarýný listeleyin.
--Select 
--	p.ProductName,
--	p.UnitPrice
--from Products p

--Müþterilerin þirket adlarýný ve bulunduklarý þehirleri alfabetik sýrayla listeleyin
--Select 
--	c.CustomerID,
--	c.City
--From Customers c
--order by c.CustomerID, c.Address

--Çalýþanlarýn ad ve soyadlarýný birleþtirerek tam isimlerini listeleyin.
--Select 
--	e.FirstName + ' ' + e.LastName as 'FullName'
--From Employees e

--Stok miktarý 10'dan az olan ürünleri listeleyin.
--Select *
--From Products p
--Where p.UnitsInStock<=10

--1998 yýlýnda yapýlan sipariþleri listeleyin
--Select * 
--From Orders o
--where o.OrderDate  between '1998-01-01' and '1998-12-30'

--Her bir kategorideki ürün sayýsýný bulun.
--select 
--	c.CategoryName,
--	COUNT(p.ProductID) as 'Ürün Sayýsý' 
--from Categories c join Products p on c.CategoryID = p.CategoryID
--group by c.CategoryName

----En pahalý 5 ürünü fiyatlarýyla birlikte listeleyin.
--Select
--	top(5)
--	p.ProductName,
--	p.UnitPrice
--from Products p
--order by p.UnitPrice desc

--Her bir ülkedeki müþteri sayýsýný bulun ve müþteri sayýsýna göre azalan sýrayla listeleyin.

--Select 
--	c.country as 'Ülke',
--	COUNT(c.CustomerID) as 'Müþteri Sayýsý'
--from Customers c
--Group by c.Country
--order by 'Müþteri Sayýsý' desc

--Nakliye ücreti 50'den fazla olan sipariþleri listeleyin.
--Select 
--	o.OrderID,
--	o.Freight
--from orders o
--where o.Freight>=50

--Her bir çalýþanýn toplam sipariþ sayýsýný bulun
--select 
--	e.FirstName + ' ' + e.LastName as 'FullName',
--	COUNT(o.OrderID) as 'Sipariþ Sayýsý'
--from Employees e join Orders o on e.EmployeeID = o.EmployeeID
--Group by e.FirstName, e.LastName

--Ürünleri kategorileriyle birlikte listeleyin.
--select 
--	p.ProductName,
--	c.CategoryName
	
--from Products p join Categories c on p.CategoryID = c.CategoryID

--Her bir sipariþin toplam tutarýný hesaplayýn.
--Select 
--	o.OrderID,
--	Sum(o.UnitPrice * o.Quantity) as Tutar
--from OrderDetails o
--Group by o.OrderID

--En çok satýlan 5 ürünü ve satýþ miktarlarýný listeleyin.
--select
--	top(5)
--	p.ProductName,
--	od.Quantity
--from OrderDetails od join Products p on od.ProductID =p.ProductID
--order by Quantity DESC

--Her bir müþterinin verdiði sipariþ sayýsýný bulun.

--select 
--	c.CustomerID,
--	Count(o.OrderID) as 'Sipariþ Sayýsý'
--from Customers c join Orders o on c.CustomerID =o.CustomerID
--Group by c.CustomerID

--Hangi kargo þirketinin kaç sipariþ taþýdýðýný listeleyin.
--select 
--	s.CompanyName,
--	count(o.OrderID) as 'Þipariþ Sayýsý'
--from Orders o join Shippers s on o.ShipVia = s.ShipperID
--Group by s.CompanyName

--Her bir çalýþanýn toplam satýþ tutarýný hesaplayýn.
--select 
--	e.FirstName + ' ' + e.LastName as 'FullName',
--	sum(od.Quantity * od.UnitPrice) as 'Tutar'
--from Employees e 
--		join Orders o on e.EmployeeID = o.EmployeeID
--			join OrderDetails od on od.OrderID =o.OrderID
--group by e.FirstName, e.LastName

--Her bir kategorideki ürünlerin ortalama fiyatýný bulun.
--select 
--	c.CategoryName,
--	AVG(p.UnitPrice) as 'Ortalama'
--from Products p join Categories c on p.CategoryID = c.CategoryID
--group by c.CategoryName

--En az 5 sipariþ veren müþterileri ve sipariþ sayýlarýný listeleyin.

--select 
--	c.CustomerID,
--	count(o.OrderID) as 'Count'
--from Customers c join Orders o on c.CustomerID = o.CustomerID
--group by c.CustomerID
--Having count(o.OrderID)>=5

--Her bir ülke için toplam satýþ tutarýný hesaplayýn.
--select 
--	o.ShipCountry,
--	sum(od.UnitPrice * od.Quantity) as Total
--from Orders o join OrderDetails od on o.OrderID = od.OrderID
--group by o.ShipCountry


--Sipariþleri, sipariþ tarihine göre yýllar ve aylar bazýnda gruplayarak toplam satýþ tutarlarýný listeleyin.

--Select 
--	Year(o.OrderDate) as 'Yil',
--	Month(o.OrderDate) as 'Ay',
--	Sum(od.UnitPrice * od.Quantity) as Total
--from Orders o join OrderDetails od on o.OrderID = od.OrderID
--group by o.OrderDate
--Order by Year(o.OrderDate) desc, Month(o.OrderDate) desc

