--T�m �r�nlerin adlar�n� ve birim fiyatlar�n� listeleyin.
--Select 
--	p.ProductName,
--	p.UnitPrice
--from Products p

--M��terilerin �irket adlar�n� ve bulunduklar� �ehirleri alfabetik s�rayla listeleyin
--Select 
--	c.CustomerID,
--	c.City
--From Customers c
--order by c.CustomerID, c.Address

--�al��anlar�n ad ve soyadlar�n� birle�tirerek tam isimlerini listeleyin.
--Select 
--	e.FirstName + ' ' + e.LastName as 'FullName'
--From Employees e

--Stok miktar� 10'dan az olan �r�nleri listeleyin.
--Select *
--From Products p
--Where p.UnitsInStock<=10

--1998 y�l�nda yap�lan sipari�leri listeleyin
--Select * 
--From Orders o
--where o.OrderDate  between '1998-01-01' and '1998-12-30'

--Her bir kategorideki �r�n say�s�n� bulun.
--select 
--	c.CategoryName,
--	COUNT(p.ProductID) as '�r�n Say�s�' 
--from Categories c join Products p on c.CategoryID = p.CategoryID
--group by c.CategoryName

----En pahal� 5 �r�n� fiyatlar�yla birlikte listeleyin.
--Select
--	top(5)
--	p.ProductName,
--	p.UnitPrice
--from Products p
--order by p.UnitPrice desc

--Her bir �lkedeki m��teri say�s�n� bulun ve m��teri say�s�na g�re azalan s�rayla listeleyin.

--Select 
--	c.country as '�lke',
--	COUNT(c.CustomerID) as 'M��teri Say�s�'
--from Customers c
--Group by c.Country
--order by 'M��teri Say�s�' desc

--Nakliye �creti 50'den fazla olan sipari�leri listeleyin.
--Select 
--	o.OrderID,
--	o.Freight
--from orders o
--where o.Freight>=50

--Her bir �al��an�n toplam sipari� say�s�n� bulun
--select 
--	e.FirstName + ' ' + e.LastName as 'FullName',
--	COUNT(o.OrderID) as 'Sipari� Say�s�'
--from Employees e join Orders o on e.EmployeeID = o.EmployeeID
--Group by e.FirstName, e.LastName

--�r�nleri kategorileriyle birlikte listeleyin.
--select 
--	p.ProductName,
--	c.CategoryName
	
--from Products p join Categories c on p.CategoryID = c.CategoryID

--Her bir sipari�in toplam tutar�n� hesaplay�n.
--Select 
--	o.OrderID,
--	Sum(o.UnitPrice * o.Quantity) as Tutar
--from OrderDetails o
--Group by o.OrderID

--En �ok sat�lan 5 �r�n� ve sat�� miktarlar�n� listeleyin.
--select
--	top(5)
--	p.ProductName,
--	od.Quantity
--from OrderDetails od join Products p on od.ProductID =p.ProductID
--order by Quantity DESC

--Her bir m��terinin verdi�i sipari� say�s�n� bulun.

--select 
--	c.CustomerID,
--	Count(o.OrderID) as 'Sipari� Say�s�'
--from Customers c join Orders o on c.CustomerID =o.CustomerID
--Group by c.CustomerID

--Hangi kargo �irketinin ka� sipari� ta��d���n� listeleyin.
--select 
--	s.CompanyName,
--	count(o.OrderID) as '�ipari� Say�s�'
--from Orders o join Shippers s on o.ShipVia = s.ShipperID
--Group by s.CompanyName

--Her bir �al��an�n toplam sat�� tutar�n� hesaplay�n.
--select 
--	e.FirstName + ' ' + e.LastName as 'FullName',
--	sum(od.Quantity * od.UnitPrice) as 'Tutar'
--from Employees e 
--		join Orders o on e.EmployeeID = o.EmployeeID
--			join OrderDetails od on od.OrderID =o.OrderID
--group by e.FirstName, e.LastName

--Her bir kategorideki �r�nlerin ortalama fiyat�n� bulun.
--select 
--	c.CategoryName,
--	AVG(p.UnitPrice) as 'Ortalama'
--from Products p join Categories c on p.CategoryID = c.CategoryID
--group by c.CategoryName

--En az 5 sipari� veren m��terileri ve sipari� say�lar�n� listeleyin.

--select 
--	c.CustomerID,
--	count(o.OrderID) as 'Count'
--from Customers c join Orders o on c.CustomerID = o.CustomerID
--group by c.CustomerID
--Having count(o.OrderID)>=5

--Her bir �lke i�in toplam sat�� tutar�n� hesaplay�n.
--select 
--	o.ShipCountry,
--	sum(od.UnitPrice * od.Quantity) as Total
--from Orders o join OrderDetails od on o.OrderID = od.OrderID
--group by o.ShipCountry


--Sipari�leri, sipari� tarihine g�re y�llar ve aylar baz�nda gruplayarak toplam sat�� tutarlar�n� listeleyin.

--Select 
--	Year(o.OrderDate) as 'Yil',
--	Month(o.OrderDate) as 'Ay',
--	Sum(od.UnitPrice * od.Quantity) as Total
--from Orders o join OrderDetails od on o.OrderID = od.OrderID
--group by o.OrderDate
--Order by Year(o.OrderDate) desc, Month(o.OrderDate) desc

