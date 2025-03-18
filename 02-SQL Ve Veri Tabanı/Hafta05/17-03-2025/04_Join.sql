Select 
	p.Name ,
	c.Name 
from Products p join Categories c 
	on p.CategoryId =c.Id;