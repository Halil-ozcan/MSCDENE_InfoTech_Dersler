--Select * 
--From Customers
--Where City='Istanbul'

--Select *
--from Customers
--where ContactName='Pelin Kaya'

--Select * 
--from Customers
--where city='Ankara' or City='Izmir'

--Select * 
--from Products
--where CategoryId=3 And SupplierId=6

--Select * 
--from Products
--where CategoryId=3 Or SupplierId=6

--Select *
--from Products
----where StockQuantity>=15 and StockQuantity<=25
--where StockQuantity between 15 and 25

--Select *
--from Transactions
--where TransactionTypeId = 2 and 
--		month(TransactionDate)=11  -- 1. aydaki olanlarý göster diyoruz.

--select * 
--from Transactions
--where TransactionDate='2024-12-17 12:49:15.693'


--Select 
--	Name,
--	Price,
--	StockQuantity,
--	Price * StockQuantity as 'Total' -- Sonradan eklediðmiz bir kolon kendimiz yaptýk.
--from Products

--select 
--	SUM(Price * StockQuantity) as 'Toplam'
--from Products

--Select 
--	Name,
--	Sum(Price * StockQuantity) as Total
--from Products
--Group By Name
--Having Sum(Price * StockQuantity)>=20000


--Select 
--	CategoryId,
--	COUNT(*) as 'Quantity'
--from Products
--group by CategoryId

--select  
--	SupplierId,
--	COUNT(*) as 'Quantity'
--from Products
--group by SupplierId

--select 
--	Name,
--	Sum(Price * StockQuantity) as Total
--from Products
--group by Name

--Select
--	SupplierId,
--	Sum(Price * StockQuantity) as Total
--from Products
--group by SupplierId
--Having sum(Price * StockQuantity)<=100000


--Select *
--from Customers
--Order by City desc


--select *
--from Customers
--order by ContactName

--select 
--	City,
--	ContactName
--from Customers
--order by city, ContactName desc


--select *
--from Transactions t
--order by t.TransactionTypeId, t.Quantity desc

select 
		t.TransactionTypeId as 'Ýþlem Türü',
		count(*) as 'Adet',
		avg(t.Quantity) as 'Ortalama'	
from Transactions t
group by t.TransactionTypeId