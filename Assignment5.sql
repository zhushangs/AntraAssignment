1.	What is an object in SQL?
	Object in a database that is used to store or reference data.
	Anything which we make from create command is known as Database Object.It can be used to hold and manipulate the data.

2.	What is Index? What are the advantages and disadvantages of using Indexes?
	Index is used to retrieve data from the database more quickly than otherwise. 
	Advantage: The users cannot see the indexes, they are just used to speed up searches/queries.
				They can be used for sorting. A post-fetch-sort operation can be eliminated.
	Disadvantage: They decrease performance on inserts, updates, and deletes. They take up space 

3.	What are the types of Indexes?
	Clustered Index.
	Non-Clustered Index.
	Unique Index.
	Filtered Index.
	Columnstore Index.
	Hash Index.

4.	Does SQL Server automatically create indexes when a table is created? If yes, under which constraints?
	SQL Server automatically creates a unique, clustered index if a clustered index does not already exist on the table or view
	It is under than primary key constraints

5.	Can a table have multiple clustered index? Why?
	No, there can be only one clustered index per table, because the data rows themselves can be stored in only one order.

6.	Can an index be created on multiple columns? Is yes, is the order of columns matter?
	Yes, order does not matter.

7.	Can indexes be created on views?
	Yes, the first index created on a view must be a unique clustered index

8.	What is normalization? What are the steps (normal forms) to achieve normalization?
	Normalization is a process and it should be carried out for every database users design.
	1st NF, 2nd NF, 3rd NF, BCNF

9.	What is denormalization and under which scenarios can it be preferable?
	Denormalization is a database optimization technique in which we add redundant data to one or more tables.
	This can help us avoid costly joins in a relational database
	To enhance query performance.
	To make a database more convenient to manage.
	To facilitate and accelerate reporting.

10.	How do you achieve Data Integrity in SQL Server?
	Data integrity refers to the accuracy, consistency, and reliability of data that is stored in the database.
	We can apply integrity to the Table by specifying a primary key, unique key, and not null.

11.	What are the different kinds of constraint do SQL Server have?
	NOT NULL, UNIQUE, PRIMARY KEY, FOREIGN KEY, CHECK ,DEFAULT, CREATE INDEX

12.	What is the difference between Primary Key and Unique Key?
	Primary key: used to serve as a unique identifier for eatch row in a table, and cannot accept null value, only one primary key, creates clustered index
	Unique key: uniquely determines a row which isnt primary key, can accept null value, more than on unique key, craets non-clustered index

13.	What is foreign key?
	A field in one table, that refers to the PRIMARY KEY in another table.

14.	Can a table have multiple foreign keys?
	Yes

15.	Does a foreign key have to be unique? Can it be null?
	No, and it cannot be null

16.	Can we create indexes on Table Variables or Temporary Tables?
	Index cannot be created in Table variable, but it can be created in temp table
 
17.	What is Transaction? What types of transaction levels are there in SQL Server?
	Transactions group a set of tasks into a single execution unit. 
	Each transaction begins with a specific task and ends when all the tasks in the group successfully complete. 
	Read Uncommitted
	Read Committed
	Repeatable Read

--1.	Write an sql statement that will display the name of each customer and the sum of order totals placed by that customer during the year 2002
Create table customer(cust_id int,  iname varchar (50)) 
create table order(order_id int,cust_id int,amount money,order_date smalldatetime)

SELECT c.iname, COUNT(o.order_id) AS Total FROM customer c
LEFT JOIN order o
ON c.cust_id = o.cust_id
WHERE DATEPART(year, order_date) = 2002
GROUP BY c.iname

 --2.  The following table is used to store information about company’s personnel: write a query that returns all employees whose last names  start with “A”.
Create table person (id int, firstname varchar(100), lastname varchar(100)) 

SELECT * FROM person WHERE lastname LIKE 'A%'

--3.  The information about company’s personnel is stored in the following table:
--The filed managed_id contains the person_id of the employee’s manager.
--Please write a query that would return the names of all top managers (an employee who does not have  a manger, and the number of people that report directly to this manager.

Create table person(person_id int primary key, manager_id int null, name varchar(100)not null) 

SELECT name FROM person WHERE manager_id IS NULL

--4

--5
