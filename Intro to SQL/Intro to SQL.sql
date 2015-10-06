--What is SQL? What is DML? What is DDL? Recite the most important SQL commands.

--SQL (Structured Query Language) is a standard interactive and programming language for getting information from and updating a database.
--A data manipulation language (DML) is a family of syntax elements similar to a computer programming language used for selecting, inserting, deleting and updating data in a database.
--Performing read-only queries of data is sometimes also considered a component of DML.
--A data definition language or data description language (DDL) is a syntax similar to a computer programming language for defining data structures, especially database schemas.
--Here are some of the most important SQL commands:
--SELECT - extracts data from a database
--UPDATE - updates data in a database
--DELETE - deletes data from a database
--INSERT INTO - inserts new data into a database
--CREATE DATABASE - creates a new database
--ALTER DATABASE - modifies a database
--CREATE TABLE - creates a new table
--ALTER TABLE - modifies a table
--DROP TABLE - deletes a table
--CREATE INDEX - creates an index (search key)
--DROP INDEX - deletes an index

--What is Transact-SQL (T-SQL)

--Transact-SQL (T-SQL) is Microsoft's and Sybase's proprietary extension to SQL. 
--T-SQL expands on the SQL standard to include procedural programming, local variables, various support functions for string processing, date processing, mathematics, etc. and changes to the DELETE and UPDATE statements.


--Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.

--Exexute https://github.com/TelerikAcademy/Databases/blob/master/07.%20Intro%20to%20SQL/Demo/Create-TelerikAcademy-Database-SQL-Script.sql

--Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

SELECT departments.Name, employees.FirstName + ' ' + employees.LastName as Manager
FROM Departments departments, Employees employees
WHERE departments.ManagerID = employees.EmployeeID

-- Write a SQL query to find all department names.
SELECT Name
FROM Departments

-- Write a SQL query to find the salary of each employee.

SELECT Salary
FROM Employees

-- Write a SQL to find the full name of each employee.

SELECT FirstName + ' ' + LastName AS FullName
FROM Employees

--Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".

SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
FROM Employees

--Write a SQL query to find all different employee salaries.

SELECT DISTINCT Salary
FROM Employees
ORDER BY Salary DESC

--Write a SQL query to find all information about the employees whose job title is "Sales Representative"

SELECT *
FROM Employees
WHERE JobTitle = 'Sales Representative'
	
-- Write a SQL query to find the names of all employees whose first name starts with "SA".

SELECT FirstName + ' ' + LastName AS FullName
FROM Employees
WHERE FirstName LIKE 'SA%'

--Write a SQL query to find the names of all employees whose last name contains "ei".

SELECT FirstName + ' ' + LastName AS FullName
FROM Employees
WHERE LastName LIKE '%ei%'

--Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].

SELECT FirstName + ' ' + LastName AS FullName, Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000
ORDER BY Salary DESC

--Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

SELECT FirstName + ' ' + LastName AS FullName, Salary
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)
ORDER BY Salary DESC

--Write a SQL query to find all employees that do not have manager.

SELECT FirstName + ' ' + LastName AS FullName
FROM Employees
WHERE ManagerID IS NULL

--Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.

SELECT FirstName + ' ' + LastName AS FullName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--Write a SQL query to find the top 5 best paid employees.

SELECT TOP 5 FirstName + ' ' + LastName AS FullName, Salary
FROM Employees
ORDER BY Salary DESC

--Write a SQL query to find all employees along with their address. Use inner join with ON clause.

SELECT employees.FirstName + ' ' + employees.LastName AS FullName, a.AddressText
FROM Employees employees 
INNER JOIN Addresses a
ON employees.AddressID = a.AddressID

--Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).

SELECT employees.FirstName + ' ' + employees.LastName AS FullName, a.AddressText
FROM Employees employees, Addresses a
WHERE employees.AddressID = a.AddressID

--Write a SQL query to find all employees along with their manager.

SELECT employees1.FirstName + ' ' + employees1.LastName AS Employee, 
employees2.FirstName + ' ' + employees2.LastName AS Manager
FROM Employees employees1, Employees employees2
WHERE employees1.ManagerID = employees2.EmployeeID

--Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.

SELECT employees.FirstName + ' ' + employees.LastName AS Employee, 
menager.FirstName + ' ' + menager.LastName AS Manager,
a.AddressText
FROM Employees employees, Employees menager, Addresses a
WHERE employees.ManagerID = menager.EmployeeID 
	AND employees.AddressID = a.AddressID

--Write a SQL query to find all departments and all town names as a single list. Use UNION

SELECT Name AS [Town/Department]
FROM Departments 
	UNION 
SELECT Name AS [Town/Department]
FROM Towns

--Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.

SELECT ISNULL(employees.FirstName + ' ' + employees.LastName, 'not responsible enought') AS Employee,
menager.FirstName + ' ' + menager.LastName AS Manager
FROM Employees employees
RIGHT JOIN Employees menager
ON employees.ManagerID = menager.EmployeeID

--right outer join
SELECT employees.FirstName + ' ' + employees.LastName AS Employee,
ISNULL(menager.FirstName + ' ' + menager.LastName, 'Unmanageable') AS Manager
FROM Employees employees
LEFT JOIN Employees menager
ON employees.ManagerID = menager.EmployeeID

--Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.

SELECT employees.FirstName + ' ' + employees.LastName AS Employee, employees.HireDate,
department.Name
FROM Employees employees, Departments department
WHERE employees.DepartmentID = department.DepartmentID AND department.Name IN ('Sales', 'Finance')
AND employees.HireDate BETWEEN '1995-01-01 00:00:00' AND '2005-12-31 00:00:00'