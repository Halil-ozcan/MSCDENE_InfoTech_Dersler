--Select GETDATE()
--Select month(GETDATE())

--Select 
--	* 
--from Employees
--where month(BirthDate) = 3

--select
--	FirstName + ' ' + LastName as '�al��an',
--	DateDiff(YEAR, BirthDate, GETDATE()) as 'Ya�'
--from Employees


--select dbo.fnUpper('engin niyazi erg�l')
--Select 
--	dbo.fnUpper(CompanyName),
--	ContactName
--from Customers

--create function FnCalculateAge(@birthdate date) returns int
--begin
--	declare @age int
--	declare @today date
--	set @today = GETDATE()
--	set @age = DATEDIFF(YEAR,@birthdate,@today)
--	return @age
--end

--Select dbo.FnCalculateAge('1975-07-16')

Select 
	e.FirstName + ' ' + e.LastName as 'FullName',
	dbo.FnCalculateAge(e.BirthDate) as 'Ya�'
from Employees e