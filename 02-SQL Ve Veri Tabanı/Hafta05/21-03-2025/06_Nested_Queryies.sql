-- Stokta En az bulunan �r�n
--Select *
--from Products p
--where p.UnitsInStock=(
--		Select 
--		min(p.UnitsInStock)
--	from Products p
--	Where p.UnitsInStock>0)

-- Ortalama Sipari� miktar�ndan fazla sipari� edilen �r�nler



--Ortalama Nakliye Giderinin �zerindeki nakliye gideri yap�lan m��teriler

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


