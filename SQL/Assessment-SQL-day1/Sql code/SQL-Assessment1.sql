--use Assessment
--create books table
Create table books(id int primary key,
title varchar(50),
author varchar(50),isbn varchar(20) unique,
published_date datetime);

--insert data into books table
insert into books(id,title,author,isbn,published_date) values
(1,'My First SQL book','mary Parker','981483029127','2012-02-22 12:08:17'),
(2,'My Second SQL book','John Mayer','857300923713','1972-07-03 09:22:45'),
(3,'My Third SQL book','Cary Flint','523120967812','2015-10-18 14:05:44');

--create review table
create table reviews(id int primary key,book_id int,reviewer_name varchar(50),
content varchar(255),
rating int,
published_date datetime,
foreign key (book_id) references books(id));

--insert data into reviews table
insert into reviews(id,book_id,reviewer_name,content,rating,published_date)values
(1,1,'John Smith','My first review',4,'2017-12-10 05:11:11.1'),
 (2, 2, 'John Smith', 'My second review', 5, '2017-10-13 15:05:12.6'),
    (3, 2, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');

----1)Write a query to fetch the details of the books written by author whose name ends with er.
select * from books
where author like '%er'

--2) Display the Title ,Author and ReviewerName for all the books from the above table
select b.title, b.author, r.reviewer_name from books b join reviews r on b.id = r.book_id;

--3) Display the reviewer name who reviewd more than one book
select reviewer_name from reviews group by reviewer_name having count(book_id)>1;

----create table another
create table Customer(id int primary key,name varchar(50),address varchar(100),age int,salary float)

--insert values in customer table
insert into Customer(id, name ,address,age,salary)values
 (1, 'RAMESH', 'AHMEDABAD',  32, 2000.00),
    (2, 'KHILAN', 'DELHI', 25, 1500.00),
    (3, 'KAUSHIK', 'KOTA', 23, 2000.00),
	(4,'CHAITALI','MUMBAI',25,6500.00),
	(5,'HARDIK','BHOPAL',27,8500.00),
	(6,'KOMAL','MP',22,4500),
	(7,'MUFFY','INDORE',24,10000)

Select * from Customer

--4)Display the Name for the customer from above customer table who live in same address which has character o anywhere in address
select name,address
from Customer
where address like '%o%'


---create table third one of order
create table orders(orderid int primary key,order_date datetime,
customer_id int,
amount float,)

select * from orders

--insert values of orders table
insert into orders(orderid,order_date,customer_id,amount)values
(102, '2009-10-08 00:00:00', 3, 3000),
       (100, '2009-10-08 00:00:00', 3, 1500),
       (101, '2008-05-20 00:00:00',2, 1560),
	   (103, '2008-05-20 00:00:00',4, 2060)

--5) Write a query to display the   Date,Total no of customer  placed order on same Date
select order_date,count(distinct customer_id) as TotalCustomer
from orders
group by order_date


---create table of employee
create table Employee(id int primary key,name varchar(50),address varchar(100),age int,salary float)


---insert into values of employess
insert into Employee(id,name,address,age,salary)values
 (1, 'RAMESH', 'AHMEDABAD',  32, 2000.00),
    (2, 'KHILAN', 'DELHI', 25, 1500.00),
    (3, 'KAUSHIK', 'KOTA', 23, 2000.00),
	(4,'CHAITALI','MUMBAI',25,6500.00),
	(5,'HARDIK','BHOPAL',27,8500.00),
	(6,'KOMAL','MP',22,NULL),
	(7,'MUFFY','INDORE',24,NULL)

select * from Employee

---6)Display the Names of the Employee in lower case, whose salary is null
select lower(name) as LowerCaseName,salary
from Employee
where salary is null

----create table of students
create table Students(reg int primary key,name varchar(100),age int,qualification varchar(100),
mobile_no varchar(15),mail_id varchar(100),location varchar(255),
gender char(1))

--insert values of Students table
insert into Students(reg,name,age,qualification,mobile_no,mail_id,location,gender)values
(2, 'SAI', 22, 'BE', '9952836777', 'SAI@GMAIL.COM', 'CHENNAI', 'M'),
(3, 'KUMAR', 20, 'BSC', '7890125648', 'KUMAR@GMAIL.COM', 'MADURAI', 'M'),
(4, 'SELVI',  22, 'B  TECH', '8904567342', 'SELVI@GMAIL.COM', 'SELAM', 'F'),
(5, 'NISHA',  25, 'ME', '7834672310', 'NISHA@GMAIL.COM', 'THENI', 'F'),
(6, 'SAISARAN',  21, 'BA', '7890345678', 'SARAN@GMAIL.COM', 'MADURAI', 'F'),
(7, 'TOM',  23, 'BCA', '8901234675', 'TOM@GMAIL.COM', 'PUNE', 'M')

select * from Students

--7)Write a sql server query to display the Gender,Total no of male and female from the above relation
select gender,count(*) as TotalEmployees
from Students
group by gender

