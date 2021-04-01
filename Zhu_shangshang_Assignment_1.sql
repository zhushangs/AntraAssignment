--1
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product

--2
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE ListPrice = 0

--3
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color is NULL

--4
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL

--5
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL
AND ListPrice > 0

--6
SELECT Name, Color
FROM Production.Product
WHERE Color IS NULL

--7
SELECT concat('NAME:', Name) 'Name', concat('COLOR:', Color) 'Color'
FROM Production.Product
WHERE Color IS NOT NULL

--8
SELECT ProductID, Name
FROM Production.Product
WHERE ProductID BETWEEN 400 AND 500

--9
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color = 'black'
OR Color = 'blue'

--10
SELECT *
FROM Production.Product
WHERE Name LIKE 'S%'

--11
SELECT TOP 6 Name, ListPrice
FROM Production.Product
WHERE Name LIKE 'S%'
ORDER BY Name

--12
SELECT Name, ListPrice
FROM Production.Product
WHERE Name LIKE '[A S]%'
ORDER BY Name

--13
SELECT Name, ListPrice
FROM Production.Product
WHERE Name LIKE 'SPO[^ K]%'
ORDER BY Name

--14
SELECT DISTINCT Color
FROM Production.Product
ORDER BY Color DESC

--15
SELECT DISTINCT ProductSubcategoryID, Color 
FROM Production.Product
WHERE Color IS NOT NULL
AND ProductSubcategoryID IS NOT NULL

--16
SELECT ProductSubCategoryID
      , LEFT([Name],35) AS [Name]
      , Color, ListPrice 
FROM Production.Product
WHERE (Color NOT IN ('Red','Black') 
	  AND ProductSubCategoryID = 1)
      OR ListPrice BETWEEN 1000 AND 2000 
ORDER BY ProductID

--17
SELECT DISTINCT ProductSubCategoryID,  Name, Color, ListPrice
FROM Production.Product
WHERE ProductSubCategoryID < 15
AND Color IN ('black', 'red', 'yellow', 'sliver')
AND ListPrice BETWEEN 500 AND 1710
AND Name NOT LIKE '%ML%' 
AND Name NOT LIKE '%300%' 
AND Name NOT LIKE '%750%' 
ORDER BY ProductSubCategoryID DESC
