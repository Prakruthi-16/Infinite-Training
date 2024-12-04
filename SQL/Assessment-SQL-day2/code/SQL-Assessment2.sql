CREATE DATABASE ASSESSMENT2
USE ASSESSMENT2

-----create table of dept
CREATE TABLE DEPT (
    DEPTNO INT PRIMARY KEY,
    DNAME VARCHAR(50),
    LOC VARCHAR(50)
);

-----insert values of dept
INSERT INTO DEPT (DEPTNO, DNAME, LOC) VALUES
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

SELECT * FROM DEPT

-----create table of emp
CREATE TABLE EMP (
    EMPNO INT PRIMARY KEY,
    ENAME VARCHAR(50),
    JOB VARCHAR(50),
    MGR INT,
    HIREDATE DATE,
    SAL FLOAT,
    COMM FLOAT,
    DEPTNO INT,
    FOREIGN KEY (DEPTNO) REFERENCES DEPT(DEPTNO)
);


-----insert value of emp
INSERT INTO EMP (EMPNO, ENAME, JOB, MGR, HIREDATE, SAL, COMM, DEPTNO) VALUES
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);

SELECT * FROM EMP

-----1).Write a query to display your birthday( day of week)
SELECT DATENAME(WEEKDAY, '2000-12-09') AS DayOfWeek

-----2).Write a query to display your age in days
SELECT DATEDIFF(DAY, '2000-12-09', GETDATE()) AS AgeInDays

-----3).Write a query to display all employees information those who joined before 5 years in the current month
SELECT *
FROM EMP
WHERE HIREDATE < DATEADD(YEAR, -5, GETDATE())

-----4).Create table Employee with empno, ename, sal, doj columns or use and perform the following operations in a single transaction
BEGIN TRANSACTION;

-- Create the Employee table
CREATE TABLE Employee (
    empno INT PRIMARY KEY,
    ename VARCHAR(50),
    sal DECIMAL(10, 2),
    doj DATE
);

---- a.Insert 3 rows
INSERT INTO Employee (empno, ename, sal, doj)
VALUES 
(1, 'John', 5000, '2015-01-01'),
(2, 'Jane', 6000, '2016-02-01'),
(3, 'Doe', 7000, '2017-03-01');

SELECT * FROM Employee


----- b.Update the second row salary with a 15% increment
UPDATE Employee
SET sal = sal * 1.15
WHERE empno = 2;


SELECT * FROM Employee

----- c.Delete the first row
BEGIN TRANSACTION;

DELETE FROM Employee
WHERE empno = 1;
ROLLBACK;

SELECT * FROM Employee


-----5).Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions

CREATE FUNCTION CalculateBonus (@DeptNo INT, @Salary DECIMAL(10, 2))
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @Bonus DECIMAL(10, 2);
    IF @DeptNo = 10
        SET @Bonus = @Salary * 0.15;
    ELSE IF @DeptNo = 20
        SET @Bonus = @Salary * 0.20;
    ELSE
        SET @Bonus = @Salary * 0.05;
    RETURN @Bonus;
END;

-----a. For Deptno 10 employees 15% of sal as bonus.
SELECT ename, sal, dbo.CalculateBonus(deptno, sal) AS bonus
FROM Emp
WHERE deptno = 10

-----b. For Deptno 20 employees  20% of sal as bonus
SELECT ename, sal, dbo.CalculateBonus(deptno, sal) AS bonus
FROM EMP
WHERE deptno = 20


-----c  For Others employees 5%of sal as bonus
SELECT ename, sal, dbo.CalculateBonus(deptno, sal) AS bonus
FROM EMP
WHERE deptno NOT IN (10, 20)


-----6). Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)
create or alter proc updateSalary
as
begin
update e
set e.sal = e.sal + 500 
from EMP e
Join DEPT D ON e.DeptNo = d.Deptno
where d.Dname = 'Sales' and e.sal < 1500;
end

exec updateSalary

select * from EMP