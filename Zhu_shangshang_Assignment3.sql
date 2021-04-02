----1
--	I would use JOINS, joins can be faster thena subquery if for the small size database
----2
--	A Common Table Expression (CTE), CTE is used for recursive query, and Substitute for a view when the general use of a view is not required.
----3
--	A table variable is a data type that can be used within a Transact-SQL batch, stored procedure, or function—and is created and defined similarly to a table.
--	It is created and defined similarly to a table, only with a strictly defined lifetime scope. 
----4
--	DELECT(DML): go through records one by one
--	TURNCATE(DDL): delete the table, and then recreate then table
--	TURNCATE is better, it is faster than delete
----5
--	Identity cloumn: the values for the column will be provided by the DBMS and not by the user and in some specific manner and restrictions
--	DELETE: Identity of column retains the identity after using DELETE Statement on table.
--	TURNCATE: Identity of the column is reset to its seed value if the table contains an identity column.
----6
--	The word TABLE in TRUNCATE TABLE is optional.
--	To remove only specific records in a table, TRUNCATE TABLE cannot be used. 
--	To remove records, must use DELETE statement that includes a WHERE clause


--1
SELECT DISTINCT c.City FROM Northwind.dbo.Customers c
INNER JOIN Northwind.dbo.Employees e
ON c.City = e.City

--2
SELECT DISTINCT c.City FROM Northwind.dbo.Customers c
WHERE c.City NOT IN
(SELECT e.City FROM Northwind.dbo.Employees e)

SELECT DISTINCT c.City FROM Northwind.dbo.Customers c
LEFT JOIN Northwind.dbo.Employees e
ON c.City = e.City
WHERE e.City IS NULL

--3
SELECT p.ProductID, p.ProductName, SUM(d.Quantity) AS TotalQuantities FROM Northwind.dbo.Products p
LEFT JOIN Northwind.dbo.[Order Details] d
ON p.ProductID = d.ProductID
GROUP BY p.ProductID, p.ProductName

--4
SELECT c.City, SUM(d.Quantity) AS TotalQuantities FROM Northwind.dbo.Customers c
LEFT JOIN Northwind.dbo.Orders o
ON c.CustomerID = o.CustomerID
LEFT JOIN Northwind.dbo.[Order Details] d
ON o.OrderID = d.OrderID
GROUP BY c.City

--5
SELECT c.City,count(c.CustomerID) as 'Customers' FROM Northwind.dbo.Customers c
GROUP BY c.City
HAVING count(c.CustomerID) >= 2
UNION
SELECT cu.City,count(cu.CustomerID) as 'Customers' FROM Northwind.dbo.Customers cu
GROUP BY cu.City
HAVING count(cu.CustomerID) >= 2


SELECT * FROM(
SELECT c.City,count(c.CustomerID) as 'Customers' FROM Northwind.dbo.Customers c
LEFT JOIN
(SELECT * FROM Northwind.dbo.Customers) cu
ON c.customerid = cu.CustomerID
GROUP BY c.City) dt
WHERE dt.Customers >= 2

--6
SELECT c.City, COUNT(ProductID) AS Product FROM Northwind.dbo.[Order Details] d 
INNER JOIN Northwind.dbo.Orders o
ON d.OrderID = o.OrderID
INNER JOIN Northwind.dbo.Customers c
ON o.CustomerID = c.CustomerID
GROUP BY c.City
HAVING COUNT(ProductID) >= 2

SELECT * FROM Northwind.dbo.Customers
SELECT * FROM Northwind.dbo.Orders
SELECT * FROM Northwind.dbo.[Order Details]



--7
SELECT DISTINCT c.CustomerID, c.ContactName FROM Northwind.dbo.Customers c
LEFT JOIN Northwind.dbo.Orders o
ON c.CustomerID = o.CustomerID
WHERE o.ShipCity <> c.City

--8
select * from
(select c.City, dt.ProductID, dt.AvgPrice, dt.TotalOrders,
dense_rank() over(partition by c.city order by dt.TotalOrders desc) rnk
from Northwind.dbo.Customers c inner join
(SELECT CustomerID, OrderID FROM Northwind.dbo.Orders) dt1
ON dt1.CustomerID = c.CustomerID
INNER JOIN
(Select OrderId, ProductID, AVG(UnitPrice) as 'AvgPrice', SUM(Quantity) AS TotalOrders from Northwind.dbo.[Order Details] group by ProductID, OrderId) dt
on dt.OrderID= dt.OrderId
) dt2
where dt2.rnk <= 5

--9
SELECT e.City FROM Northwind.dbo.Employees e
WHERE e.City NOT IN(
SELECT o.ShipCity FROM Northwind.dbo.Orders o)

SELECT DISTINCT e.City FROM Northwind.dbo.Employees e
WHERE NOT EXISTS(SELECT 1 FROM Northwind.dbo.Orders o WHERE o.ShipCity=e.City)

--10
select top 1 * from
(select o.ShipCity, dt.Total, 
dense_rank() over(partition by o.ShipCity order by dt.Total desc) rnk
from Northwind.dbo.Orders o inner join
(Select OrderID, COUNT(OrderID) as 'Total' from Northwind.dbo.[Order Details] GROUP BY OrderID) dt
on dt.OrderID= o.OrderID
)dt2
where dt2.rnk = 1
ORDER BY dt2.Total DESC


select * from
(select o.ShipCity, dt.Total, 
dense_rank() over(partition by o.ShipCity order by dt.Total desc) rnk
from Northwind.dbo.Orders o inner join
(Select OrderID, SUM(Quantity) as 'Total' from Northwind.dbo.[Order Details] GROUP BY OrderID) dt
on dt.OrderID= o.OrderID
)dt2
where dt2.rnk = 1


SELECT o.ShipCity, COUNT(o.OrderID) FROM Northwind.dbo.Orders o
LEFT JOIN Northwind.dbo.[Order Details] d
ON o.OrderID = d.OrderID


SELECT * FROM Northwind.dbo.Orders
SELECT * FROM Northwind.dbo.[Order Details]


--11
--use CTE
--WITH CTE AS
--(
--SELECT *,ROW_NUMBER() OVER (PARTITION BY col1,col2,col3 ORDER BY col1,col2,col3) AS RN
--FROM MyTable
--)

--DELETE FROM CTE WHERE RN<>1

--12
SELECT * FROM Employee
WHERE empid  <> mgrid

--13
select * from
(select d.deptname, dt.TotalEmployees, 
dense_rank() over(partition by d.deptname order by dt.TotalEmployees desc) rnk
from Dept d inner join
(Select empid, count(empid) as 'TotalEmployees' from Employees group by empid)dt
on dt.deptid= c.deptid
)dt2
where dt2.rnk = 1

--14
select * from
(select e.empid,e.salary, dt.deptid
dense_rank() over(partition by e.empid order by salary desc) rnk
from Employee e inner join
(Select deptid from Dept)dt
on dt.deptid= c.deptid
)dt2
where dt2.rnk <=3
