-- Stokta En az bulunan Ürün
--Select *
--from Products p
--where p.UnitsInStock=(
--		Select 
--		min(p.UnitsInStock)
--	from Products p
--	Where p.UnitsInStock>0)

-- Ortalama Sipariþ miktarýndan fazla sipariþ edilen ürünler



--Ortalama Nakliye Giderinin üzerindeki nakliye gideri yapýlan müþteriler

Select 
	ord.CustomerID,
	c.CompanyName,
	ord.Freight
From Orders ord join Customers c on ord.CustomerID = c.CustomerID
where ord.Freight>(
	Select 
		avg(o.Freight)
		from Orders o)
order by ord.Freight desc


