--1
select * from
(select o.ShipCity, dt.ProductID, dt.TotalQuantity, 
dense_rank() over(partition by o.ShipCity order by dt.TotalQuantity desc) rnk
from Northwind.dbo.Orders o inner join
(Select OrderID, ProductID, SUM(Quantity) as 'TotalQuantity' FROM Northwind.dbo.[Order Details] group by ProductID, OrderID) dt
on dt.OrderID= o.OrderID) dt2
where dt2.rnk <=3

SELECT * FROM Northwind.dbo.Products
SELECT * FROM Northwind.dbo.Orders
SELECT * FROM Northwind.dbo.[Order Details]
SELECT * FROM Northwind.dbo.Customers

--2
SELECT cur.LocName, cur.Distance, ISNULL(nex.Distance, 0) - cur.Distance
FROM A AS cur
LEFT JOIN A AS nex
ON nex.LocName = (SELECT MIN(LocName) FROM A WHERE LocName > cur.LocName)

--3
WITH CTE AS
(
SELECT *,ROW_NUMBER() OVER (PARTITION BY Name, Salary, Department ORDER BY Name,Salary,Department) AS RN
FROM Employee
)

DELETE FROM CTE WHERE RN<>1