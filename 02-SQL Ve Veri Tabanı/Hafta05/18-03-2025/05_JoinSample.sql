--select 
--	p.ProductName,
--	c.CategoryName
--from Products p join Categories c on p.CategoryID = c.CategoryID
--where CategoryName = 'Beverages'


--Maksimum, Minimum ve ortalama fiyatlarý ve ürün sayýlarýný gösterelim



/*
	Join:
	Birden fazla tabloyu birleþtirmek için kullandýðýmýz yapýya join adýný veriyoruz. ihtiyaca göre farklý join tiplerini kullanabiliyoruz.
	1) Join(inner): Her iki taraftaki tabloda eþleþen kayýtlarý birleþtirerek getirir.
	2) Left Join: Sol taraftaki tablodan tüm kayýtlarý sað tarafataki tablodan ise eþleþenleri getirir.
	3) Right Join: sað taraftaki tablodan tüm kayýtlarý sol tarafataki tablodan ise eþleþenleri getirir.
	4) outher join sað ve saoldaki eþleþmelere bakmaksýzýn bütün tabloyu getirir.
*/


--select * from Categories c left join Products p
--		on p.CategoryID = c.CategoryID

--select * from Categories c right join Products p
--		on p.CategoryID = c.CategoryID

--select * 
--from Categories c left join Products p
--		on p.CategoryID= c.CategoryID
--where p.CategoryID is null -- productda categoryId si null olanlarý getir demek. 

--select * from Categories c full outer join Products p
--		on p.CategoryID = c.CategoryID









-- Samples
--1)Hangis Sipariþ hangi çalýþan tarafýndan hangi müþteri için verilmiþtir. 

--select
--	o.OrderID,
--	o.OrderDate,
--	e.FirstName + ' '+e.LastName as 'Employee',
--	c.CompanyName as 'Customer'
--from Orders o join Employees e on o.EmployeeID = e.EmployeeID
--	join Customers c on o.CustomerID = c.CustomerID


--2) Bugüne kadar hangi ülkelere kargo gönderimi yapmýþýz?

--select distinct o.ShipCountry -- distinct birden fazla olan bir þeyi tek halinde getiriyor.
--from Orders o

--3) Bugüne kadar hangi ülkeye kaç kez kargo göndermiþiz?
--select 
--	o.ShipCountry,
--	count(o.ShipCountry) as 'Count'
--from Orders o
--group by ShipCountry
--Order by 'Count' desc
 
 --3) Bugüne kadar en çok hangi ülkeye kaç kez kargo göndermiþiz?


 --5) Kategorilere göre stok miktarýný görüntüle 

 --select 
	--c.CategoryName,
	--sum(p.UnitsInStock) as Amount
 --from Categories c join Products p on c.CategoryID = p.CategoryID
 --group by c.CategoryName

 --6) Kategorilere göre Satýþ Tutarlarý
-- Select 
--	c.CategoryName,
--	sum(od.UnitPrice * od.Quantity) as Total
-- from Categories c join Products p on c.CategoryID = p.ProductID 
--		join OrderDetails od on od.ProductID=p.ProductID 
--group by c.CategoryName


--7) Ürünlere Göre Satýþ Tutarlarý
--select 
--	p.ProductName,
--	sum(od.UnitPrice * od.Quantity) as Total
--from OrderDetails od join Products p on od.ProductID = p.ProductID
--group by p.ProductName

--8) Bölgelere göre Satýþ Tutarlarý
--select 
--	r.RegionDescription as 'Bölge',
--	sum(od.UnitPrice * od.Quantity) as Total
--from 
--	Region r 
--	join Territories t on r.RegionID = t.RegionID
--		join EmployeeTerritories et on t.TerritoryID = et.TerritoryID
--			join Employees e on et.EmployeeID = e.EmployeeID
--				join Orders o on e.EmployeeID = o.EmployeeID
--					Join OrderDetails od on o.OrderID = od.OrderID
--group by r.RegionDescription


-- 9) En çok satýþ Tutarýna(Ýndirimli Tutar) sahip ilk 3 ürünü listeleyelim.

--Select
--	Top(3)
--	P.ProductName,
--	cast(Sum(od.Quantity * od.UnitPrice * (1-od.Discount)) as decimal(10,2)) AS 'Tutar' 
--from OrderDetails od  join Products p on od.ProductID = p.ProductID
--GROUP BY p.ProductName 
--Order By 'Tutar' desc

--10) Hangi Bölgede hangi üründen kaç paralýk satýþ yapmýþýz.

Select 
	r.RegionDescription as 'Bölge',
	p.ProductName as 'Ürün',
	Sum(od.Quantity * od.UnitPrice) as 'Tutar'
from Territories t 
	join Region r on t.RegionID = r.RegionID
		join EmployeeTerritories et on t.TerritoryID = et.TerritoryID
			Join Employees e on e.EmployeeID = et.EmployeeID
				Join Orders o on o.EmployeeID = e.EmployeeID
					Join OrderDetails od on o.OrderID = od.OrderID
						Join Products p on p.ProductID = od.ProductID
group by r.RegionDescription, p.ProductName
order by r.RegionDescription, p.ProductName







--select * from Products
--select * from Categories
--select * 
--from Products
--where UnitsInStock>=100 and UnitPrice>=20
--select * from Orders
--select * from OrderDetails

