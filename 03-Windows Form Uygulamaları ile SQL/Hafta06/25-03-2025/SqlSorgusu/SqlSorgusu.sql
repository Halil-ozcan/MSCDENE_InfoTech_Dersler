--select 
--	CategoryID as 'Id',
--	CategoryName as 'Name',
--	Description
--from Categories

--select 
--	p.ProductID as 'Id',
--	p.ProductName as 'Name', 
--	p.CategoryID as 'CategoryId',
--	p.UnitPrice as 'Price',
--	UnitsInStock as 'Stock',
--	c.CategoryName as 'Category'
--from Products p  join Categories c on p.CategoryID = c.CategoryID

--select 
--	p.ProductID as 'Id',
--	p.ProductName as 'Name', 
--	p.CategoryID as 'CategoryId',
--	p.UnitPrice as 'Price',
--	UnitsInStock as 'Stock'
--from Products p where ProductID=7

--select * from Products

--update Products 
--set
--	ProductName ='',
--	CategoryID=0,
--	UnitPrice =0,
--	UnitsInStock=50
--where ProductID = 1

--insert into Products(ProductName, UnitPrice, UnitsInStock, CategoryID)
--values
--	('',0,0,1)

--delete Products where ProductID=81
Select
    p.ProductID as 'Id',
    p.ProductName as 'Name', 
    p.CategoryID as 'CategoryId',
    p.UnitPrice as 'Price',
    UnitsInStock as 'Stock',
    c.CategoryName as 'Category'
from Products p  join Categories c on p.CategoryID = c.CategoryID
where p.ProductName like 'c%'
order by p.ProductId desc