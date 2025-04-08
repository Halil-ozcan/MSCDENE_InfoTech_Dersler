--select 
--	CategoryID as 'Id',
--	CategoryName as 'Name',
--	Description
--from Categories

--select 
--	p.ProductID,
--	p.ProductName, 
--	p.CategoryID ,
--	p.UnitPrice,
--	UnitsInStock
--from Products p  
--where ProductID = 2

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
--	ProductName ='@p1',
--	CategoryID=@p2,
--	UnitPrice =@p3,
--	UnitsInStock=@p4
--where ProductID = @p0

--insert into Products(ProductName, CategoryID, UnitPrice, UnitsInStock)
--values
--	(@p1,@p2,@p3,@p4)
--select scope_identity()

--delete Products where ProductID=@p1
--Select
--    p.ProductID as 'Id',
--    p.ProductName as 'Name', 
--    p.CategoryID as 'CategoryId',
--    p.UnitPrice as 'Price',
--    UnitsInStock as 'Stock',
--    c.CategoryName as 'Category'
--from Products p  join Categories c on p.CategoryID = c.CategoryID
--where p.ProductName like 'c%'
--order by p.ProductId desc

--select 
--	c.CategoryID,
--	c.CategoryName,
--	c.Description
--from Categories c

--select 
--	c.CategoryID,
--	c.CategoryName,
--	c.Description
--from Categories c
--where c.CategoryID = @c1

--insert into Categories(CategoryName,Description)
--values
--	(@p1,@p2)

--update Categories
--set
--	CategoryName = @p1,
--	Description = @p2
--where CategoryID = @p0

delete Categories where CategoryID=@c0
