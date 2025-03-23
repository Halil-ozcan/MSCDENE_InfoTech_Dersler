--Select GETDATE()
--Select month(GETDATE())

--Select 
--	* 
--from Employees
--where month(BirthDate) = 3

--select
--	FirstName + ' ' + LastName as 'Çalýþan',
--	DateDiff(YEAR, BirthDate, GETDATE()) as 'Yaþ'
--from Employees


--select dbo.fnUpper('engin niyazi ergül')
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
	dbo.FnCalculateAge(e.BirthDate) as 'Yaþ'
from Employees e