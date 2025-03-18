--select 
--	p.ProductName,
--	c.CategoryName
--from Products p join Categories c on p.CategoryID = c.CategoryID
--where CategoryName = 'Beverages'


--Maksimum, Minimum ve ortalama fiyatlar� ve �r�n say�lar�n� g�sterelim



/*
	Join:
	Birden fazla tabloyu birle�tirmek i�in kulland���m�z yap�ya join ad�n� veriyoruz. ihtiyaca g�re farkl� join tiplerini kullanabiliyoruz.
	1) Join(inner): Her iki taraftaki tabloda e�le�en kay�tlar� birle�tirerek getirir.
	2) Left Join: Sol taraftaki tablodan t�m kay�tlar� sa� tarafataki tablodan ise e�le�enleri getirir.
	3) Right Join: sa� taraftaki tablodan t�m kay�tlar� sol tarafataki tablodan ise e�le�enleri getirir.
	4) outher join sa� ve saoldaki e�le�melere bakmaks�z�n b�t�n tabloyu getirir.
*/


--select * from Categories c left join Products p
--		on p.CategoryID = c.CategoryID

--select * from Categories c right join Products p
--		on p.CategoryID = c.CategoryID

--select * 
--from Categories c left join Products p
--		on p.CategoryID= c.CategoryID
--where p.CategoryID is null -- productda categoryId si null olanlar� getir demek. 

--select * from Categories c full outer join Products p
--		on p.CategoryID = c.CategoryID









-- Samples
--1)Hangis Sipari� hangi �al��an taraf�ndan hangi m��teri i�in verilmi�tir. 

--select
--	o.OrderID,
--	o.OrderDate,
--	e.FirstName + ' '+e.LastName as 'Employee',
--	c.CompanyName as 'Customer'
--from Orders o join Employees e on o.EmployeeID = e.EmployeeID
--	join Customers c on o.CustomerID = c.CustomerID


--2) Bug�ne kadar hangi �lkelere kargo g�nderimi yapm���z?

--select distinct o.ShipCountry -- distinct birden fazla olan bir �eyi tek halinde getiriyor.
--from Orders o

--3) Bug�ne kadar hangi �lkeye ka� kez kargo g�ndermi�iz?
--select 
--	o.ShipCountry,
--	count(o.ShipCountry) as 'Count'
--from Orders o
--group by ShipCountry
--Order by 'Count' desc
 
 --3) Bug�ne kadar en �ok hangi �lkeye ka� kez kargo g�ndermi�iz?


 --5) Kategorilere g�re stok miktar�n� g�r�nt�le 

 --select 
	--c.CategoryName,
	--sum(p.UnitsInStock) as Amount
 --from Categories c join Products p on c.CategoryID = p.CategoryID
 --group by c.CategoryName

 --6) Kategorilere g�re Sat�� Tutarlar�
-- Select 
--	c.CategoryName,
--	sum(od.UnitPrice * od.Quantity) as Total
-- from Categories c join Products p on c.CategoryID = p.ProductID 
--		join OrderDetails od on od.ProductID=p.ProductID 
--group by c.CategoryName


--7) �r�nlere G�re Sat�� Tutarlar�
--select 
--	p.ProductName,
--	sum(od.UnitPrice * od.Quantity) as Total
--from OrderDetails od join Products p on od.ProductID = p.ProductID
--group by p.ProductName

--8) B�lgelere g�re Sat�� Tutarlar�
--select 
--	r.RegionDescription as 'B�lge',
--	sum(od.UnitPrice * od.Quantity) as Total
--from 
--	Region r 
--	join Territories t on r.RegionID = t.RegionID
--		join EmployeeTerritories et on t.TerritoryID = et.TerritoryID
--			join Employees e on et.EmployeeID = e.EmployeeID
--				join Orders o on e.EmployeeID = o.EmployeeID
--					Join OrderDetails od on o.OrderID = od.OrderID
--group by r.RegionDescription


-- 9) En �ok sat�� Tutar�na(�ndirimli Tutar) sahip ilk 3 �r�n� listeleyelim.

--Select
--	Top(3)
--	P.ProductName,
--	cast(Sum(od.Quantity * od.UnitPrice * (1-od.Discount)) as decimal(10,2)) AS 'Tutar' 
--from OrderDetails od  join Products p on od.ProductID = p.ProductID
--GROUP BY p.ProductName 
--Order By 'Tutar' desc

--10) Hangi B�lgede hangi �r�nden ka� paral�k sat�� yapm���z.

Select 
	r.RegionDescription as 'B�lge',
	p.ProductName as '�r�n',
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

