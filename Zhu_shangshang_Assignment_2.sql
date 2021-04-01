--1.	What is a result set?
		--The SQL statements that read data from a database query, return the data in a result set

--2.	What is the difference between Union and Union All?
		--Union: cannot used in recursive CTE, return unique record, sort result set based on first column of first select statement
		--Union All: can be used in recursive CTE, return duplicate records too, will not sort result set

--3.	What are the other Set Operators SQL Server has?
		--INTERSECT MINUS

--4.	What is the difference between Union and Join?
		--Union: combine result set of two or more SELECT statement, it combines data into new distinct rows, number of columns selected from each table shoud be same
		--Join: combines data from many tables based on a matched condition, it cambines data into new columns, number of cloumns selected from each table may not be same

--5.	What is the difference between INNER JOIN and FULL JOIN?
		--INNER JOIN returns only the matching rows between both the tables, non-matching rows are eliminated. 
		--FULL JOIN returns all rows from both the tables, including non-matching rows from both the tables

--6.	What is difference between left join and outer join
		--Left Join: Returns all the rows from the LEFT table and matching records between both the tables. 
		--Outer Join: It combines the result of the Left Outer Join and Right Outer Join.

--7.	What is cross join?
		--cross join: generate a paired combination of each row of the first table with each row of the second table. 

--8.	What is the difference between WHERE clause and HAVING clause?
		--WHERE:  filter the records from the table or used while joining more than one table, is used before GROUP BY Clause
		--HAVING Clause: filter the records from the groups based on the specified condition, is used after GROUP BY Clause.

--9.	Can there be multiple group by columns?
		--Yes, a grouping can consist multiple columns


--1 
SELECT COUNT(ProductID) FROM Production.Product

--2
SELECT COUNT(ProductID) FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL

--3
SELECT ProductSubcategoryID, COUNT(*) AS CountedProducts
FROM Production.Product
GROUP BY ProductSubcategoryID

--4
SELECT COUNT(ProductID) FROM Production.Product
WHERE ProductSubcategoryID IS NULL

--5
SELECT * FROM Production.ProductInventory

--6
SELECT ProductID, SUM(Quantity) AS TheSum 
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100

--7
SELECT Shelf, ProductID, Quantity AS TheSum 
FROM Production.ProductInventory
WHERE LocationID = 40
AND Quantity < 100

--8
SELECT AVG(Quantity) AS AVERAGE
FROM Production.ProductInventory
WHERE LocationID = 10

--9
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY Shelf, ProductID

--10
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY Shelf, ProductID
HAVING Shelf <> 'N/A'

--11
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS TheAvg FROM Production.Product 
GROUP BY Color, Class
HAVING Class IS NOT NULL
AND Color IS NOT NULL

--12
SELECT r.CountryRegionCode AS Country, s.StateProvinceCode AS Province FROM Person.CountryRegion r
LEFT JOIN Person.StateProvince s
ON r.CountryRegionCode = s.CountryRegionCode

--13
SELECT r.CountryRegionCode AS Country, s.StateProvinceCode AS Province FROM Person.CountryRegion r
LEFT JOIN Person.StateProvince s
ON r.CountryRegionCode = s.CountryRegionCode
WHERE r.Name = 'Germany'
OR r.Name = 'Canada'

--14
SELECT d.ProductID FROM Northwind.dbo.[Order Details] d
LEFT JOIN Northwind.dbo.Orders o
ON d.OrderID = o.OrderID
WHERE DATEDIFF(year, o.OrderDate,GETDATE()) <= 25

--15
SELECT TOP 5 o.ShipPostalCode, SUM(d.Quantity) AS Quantity FROM Northwind.dbo.[Order Details] d
LEFT JOIN Northwind.dbo.Orders o
ON d.OrderID = o.OrderID
GROUP BY o.ShipPostalCode
ORDER BY Quantity DESC

--16
SELECT TOP 5 o.ShipPostalCode, SUM(d.Quantity) AS Quantity FROM Northwind.dbo.[Order Details] d
LEFT JOIN Northwind.dbo.Orders o
ON d.OrderID = o.OrderID
WHERE DATEDIFF(year, o.OrderDate,GETDATE()) <= 20
GROUP BY o.ShipPostalCode
ORDER BY Quantity DESC

--17
SELECT City, COUNT(*) AS Customers FROM Northwind.dbo.Customers 
GROUP BY City

--18
SELECT City, COUNT(*) AS Customers FROM Northwind.dbo.Customers 
GROUP BY City
HAVING COUNT(*) > 10

--19
SELECT DISTINCT c.ContactName FROM Northwind.dbo.Customers c
LEFT JOIN Northwind.dbo.Orders o
ON c.CustomerID = o.CustomerID
WHERE o.OrderDate >= '1998-01-01'

--20
SELECT c.ContactName FROM Northwind.dbo.Customers c
LEFT JOIN Northwind.dbo.Orders o
ON c.CustomerID = o.CustomerID
ORDER BY o.OrderDate DESC

--21
SELECT c.ContactName, SUM(d.Quantity) AS Quantity FROM Northwind.dbo.Customers c
JOIN Northwind.dbo.Orders o
ON c.CustomerID = o.CustomerID
JOIN Northwind.dbo.[Order Details] d
ON o.OrderID = d.OrderID
GROUP BY c.ContactName

--22
SELECT o.CustomerID, SUM(d.Quantity) AS TheSum FROM Northwind.dbo.Orders o
LEFT JOIN Northwind.dbo.[Order Details] d
ON o.OrderID = d.OrderID
GROUP BY o.CustomerID
HAVING SUM(d.Quantity) > 100

--23
SELECT DISTINCT s.CompanyName AS 'Supplier Company Name', sh.CompanyName AS 'Shipping Company Name' FROM Northwind.dbo.Orders o
JOIN Northwind.dbo.Shippers sh
ON o.ShipVia = sh.ShipperID
JOIN Northwind.dbo.[Order Details] d
ON o.OrderID = d.OrderID
JOIN Northwind.dbo.Products p
ON d.ProductID = p.ProductID
JOIN Northwind.dbo.Suppliers s
ON s.SupplierID = p.SupplierID

SELECT * FROM Northwind.dbo.Orders
SELECT * FROM Northwind.dbo.Shippers
SELECT * FROM Northwind.dbo.Suppliers
SELECT * FROM Northwind.dbo.[Order Details]



--24
SELECT p.ProductName, o.OrderDate FROM Northwind.dbo.Orders o
JOIN Northwind.dbo.[Order Details] d
ON o.OrderID = d.OrderID
JOIN Northwind.dbo.Products p
ON d.ProductID = p.ProductID

SELECT * FROM Northwind.dbo.Orders
SELECT * FROM Northwind.dbo.Products
SELECT * FROM Northwind.dbo.[Order Details]

--25
SELECT DISTINCT e.EmployeeID, e.FirstName, e.LastName FROM Northwind.dbo.Employees e
INNER JOIN Northwind.dbo.Employees ee
ON e.Title = ee.Title
WHERE e.EmployeeID <> ee.EmployeeID

--26
SELECT e.EmployeeID AS 'ManagerID',
       count(*) AS 'Employees'
FROM Northwind.dbo.Employees e,
     Northwind.dbo.Employees ee
WHERE e.EmployeeID = ee.ReportsTo
GROUP BY e.EmployeeID
HAVING count(*) > 2

--27
SELECT c.City, c. Northwind.dbo.Customers c

SELECT * FROM Northwind.dbo.Customers
SELECT * FROM Northwind.dbo.Suppliers


--28
SELECT T1.* FROM T1
INNER JOIN T2
ON T1.F1 = T2.F2

result: 2, 3

--29
SELECT T1.* FROM T1
LEFT OUTER JOIN T2
ON T1.F1 = T2.F2

result: 1, 2, 3
