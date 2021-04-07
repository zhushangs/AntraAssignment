--1
--View:  a virtual table based on the result-set of an SQL statement
--Benefit: can simplify how users work with data, enable user to create a backward compatible interface for a table with its schema changes, and able to customize data

--2
--No

--3
--stored Procedure: groups one or more Transact-SQL statements into a logical unit, stored as an object in a SQL Server database 
--benefit: increase database security, Faster execution, help centralize your Transact-SQL code in the data tier, help reduce network traffic for larger ad hoc queries

--4
--View: showcasing data stored in the database tables
--Stored Procedure: a group of statements that can be executed

--5
--function: it is mandatory to use the RETURNS and RETURN arguments
--Stored Procedure: procedure can return zero or n values

--6
--Yes

--7
--Yes, because Stored procedures encourage code reusability

--8
--Trigger: a special type of stored procedure that get executed when a specific event happens.
--DDL Trigger
--DML Triger

--9
--Insert, Delete, Update statement on a specific table
--CREATE, ALTER , or DROP statement on any schema object

--10
--Trigger: a stored procedure that runs automatically when various events happen
--Stored Procedure: a pieces of the code in written in PL/SQL to do some specific task

SELECT * FROM Region
SELECT * FROM Territories
SELECT * FROM Employees
SELECT * FROM EmployeeTerritories

--1
SELECT * FROM Region WITH (tablockx)
INSERT INTO Region(RegionID, RegionDescription) VALUES (5, 'Middle Earth')

SELECT * FROM Territories WITH (tablockx)
INSERT INTO Territories(TerritoryID ,TerritoryDescription, RegionID) VALUES(261205, 'Gondor', 5)

SELECT * FROM Employees WITH (tablockx)
INSERT INTO Employees (FirstName, LastName ) VALUES('Aragorn', 'King')

--2
SELECT * FROM Territories WITH (tablockx)
UPDATE Territories
SET TerritoryDescription = 'Arnor'
WHERE TerritoryDescription = 'Gondor'

--3
SELECT * FROM Territories WITH (tablockx)

alter table Territories nocheck constraint all

DELETE FROM Region
WHERE RegionDescription = 'Middle Earth'

alter table Territories check constraint all

--4
CREATE VIEW view_product_order_zhu
AS
SELECT ProductID, SUM(Quantity) AS Total FROM [Order Details]
GROUP BY ProductID
GO

SELECT * FROM view_product_order_zhu

--5
CREATE PROC sp_product_order_quantity_zhu
@id int,
@total int out
AS
BEGIN
	SELECT @total = SUM(Quantity) FROM [Order Details] WHERE ProductID = @id
END

DECLARE @tot int
exec sp_product_order_quantity_zhu 11, @tot out
print @tot

--6
CREATE PROC sp_product_order_city_zhu
@name varchar(20),
@city varchar(20) out,
@total int out
AS
BEGIN
	SELECT * FROM
	(
	SELECT o.ShipCity, SUM(d.Quantity) AS Total,
	DENSE_RANK() OVER (ORDER BY SUM(d.Quantity) DESC) AS RANK
	FROM Orders o
	LEFT JOIN [Order Details] d
	ON o.OrderID = d.OrderID
	LEFT JOIN Products p
	ON d.ProductID = p.ProductID
	WHERE p.ProductName = @name
	GROUP BY o.ShipCity )dt
	WHERE dt.RANK <= 5
END

DECLARE @tot int, @cities varchar(20)
exec sp_product_order_city_zhu 'Chai', @cities out, @tot out


	--SELECT TOP 5 o.ShipCity, SUM(d.Quantity) AS Total FROM Orders o
	--LEFT JOIN [Order Details] d
	--ON o.OrderID = d.OrderID
	--LEFT JOIN Products p
	--ON d.ProductID = p.ProductID
	--WHERE p.ProductName = 'Chai'
	--GROUP BY o.ShipCity 
	--ORDER BY SUM(d.Quantity) DESC

	--SELECT TOP(5) @city = o.ShipCity, @total = SUM(d.Quantity) FROM Orders o
	--LEFT JOIN [Order Details] d
	--ON o.OrderID = d.OrderID
	--LEFT JOIN Products p
	--ON d.ProductID = p.ProductID
	--WHERE p.ProductName = @name
	--GROUP BY o.ShipCity 
	--ORDER BY SUM(d.Quantity) DESC


--7
SELECT * FROM Region WITH (TABLOCKX)
SELECT * FROM Territories WITH (TABLOCKX)
SELECT * FROM EmployeeTerritories WITH (TABLOCKX)
SELECT * FROM Employees WITH (TABLOCKX)


CREATE PROC sp_move_employees_zhu
@terroity varchar(30) = 'tory'
AS
IF EXISTS(
	SELECT e.FirstName, e.LastName FROM Employees e
	LEFT JOIN EmployeeTerritories et
	ON e.EmployeeID = et.EmployeeID
	LEFT JOIN Territories te
	ON et.TerritoryID = te.TerritoryID
	WHERE te.TerritoryDescription = 'Tory'
)
BEGIN
	INSERT INTO Territories values (54481, 'Stevens Point' , 3)
END

exec sp_move_employees_zhu


--8
SELECT * FROM Region
SELECT * FROM Territories
SELECT * FROM EmployeeTerritories
SELECT * FROM Employees

CREATE TRIGGER move_Trigger
ON Territories
FOR UPDATE
AS
BEGIN
	UPDATE Territories
	SET TerritoryDescription = 'Troy'
	WHERE TerritoryDescription = 'Stevens Point'
END


--9
CREATE TABLE city_zhu (
    id int NOT NULL PRIMARY KEY,
    City varchar(20),
);
INSERT INTO city_zhu VALUES(1, 'Seattle')
INSERT INTO city_zhu VALUES(2, 'Green Bay')


CREATE TABLE people_zhu (
   id int,
   Name varchar(20),
   City int foreign key references city_zhu(id) on delete cascade
);

INSERT INTO people_zhu VALUES(1, 'Aaron Rodgers', 2)
INSERT INTO people_zhu VALUES(2, 'Russell Wilson', 1)
INSERT INTO people_zhu VALUES(2, 'Jody Nelson', 1)

DELETE FROM city_zhu WHERE City = 'Seattle'


--10
select * from Employees

CREATE PROC sp_birthday_employees_zhu
AS
BEGIN
		SELECT EmployeeID, LastName, FirstName, BirthDate
		INTO feb_employ
		FROM Employees
		WHERE DATEPART(MONTH, BirthDate) = 02
END


--11
SELECT * FROM Orders
SELECT * FROM [Order Details]
SELECT * FROM Customers

CREATE PROC sp_zhu_1
AS
BEGIN
	SELECT c.City, COUNT(o.OrderID) AS Total FROM Customers c
	LEFT JOIN Orders o
	ON c.CustomerID = o.CustomerID
	WHERE c.CustomerID not in (SELECT CustomerID FROM Customers)
	GROUP BY c.City
	HAVING COUNT(o.OrderID) <= 1

END


CREATE PROC sp_zhu_2
AS
BEGIN
	SELECT c.City, COUNT(o.OrderID) AS Total FROM Customers c
	LEFT JOIN Orders o
	ON c.CustomerID = o.CustomerID
	LEFT JOIN Customers cc
	ON c.CustomerID = cc.CustomerID
	WHERE c.CustomerID <> cc.CustomerID
	GROUP BY c.City
	HAVING COUNT(o.OrderID) <= 1
END

--12
SELECT * FROM (
   SELECT 'table1' tname, col1, col2, col3 FROM table1
   UNION ALL
   SELECT 'table2' tname, col1, col2, col3 FROM table2
) t
GROUP BY col1, col2, col3
HAVING count(*) = 1

--14
SELECT CASE
	WHEN LEN(MIDDLENAME) > 0 THEN CONCAT(FIRSTNAME, LASTNAME, MIDDLENAME, '.') 
	ELSE CONCAT(FIRSTNAME, LASTNAME)
	END AS 'FULL NAME'
FROM TABLE

--15
SELECT TOP 1 Student, MAX(Marks) FROM TABLE
WHERE Sex = 'F'

--16
SELECT * FROM TABLE
ORDER BY Sex DESC