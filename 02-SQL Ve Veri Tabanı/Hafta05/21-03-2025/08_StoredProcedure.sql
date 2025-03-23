--Create procedure spSample as 
--	Select *
--	from Products p
--	where p.CategoryID =1
--	order by p.UnitPrice desc
--go

--execute spSample

--execute dbo.[Sales by Year] '1997-01-01','1997-12-31'

--create procedure spGetOrdersWithTotal as
--	Select 
--		od.OrderID,
--		cast(sum(od.UnitPrice * od.Quantity*(1-od.Discount)) as decimal (10,2)) as Total
-- 	from OrderDetails od
--	group by od.OrderID
--	order by total
--go

--execute spGetOrdersWithTotal

--execute SalesByCategory 'Beverages'

--create procedure spGetProductsByCategory @categoryName nvarchar(max) as
--	Select 
--		c.CategoryName,
--		p.ProductName,
--		p.UnitPrice
--	from Products p join Categories c on p.CategoryID = c.CategoryID
--	where c.CategoryName = @categoryName
--	order by p.UnitPrice desc
--go

--execute spGetProductsByCategory 'Beverages'

