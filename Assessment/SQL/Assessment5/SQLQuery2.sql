create database Assessment
use Assessment
--creating a table books
create table books (
    id int identity(1,1) primary key,
    title nvarchar(200) not null,
    author nvarchar(100) not null,
    isbn bigint unique not null,
    published_date datetime not null
);
--inserting value
insert into books (title, author, isbn, published_date) values
('my first sql book', 'mary parker', 981483029127, '2012-02-22 12:08:17'),
('my second sql book', 'john mayer', 857300923713, '1972-07-03 09:22:45'),
('my third sql book', 'cary flint', 523120967812, '2015-10-18 14:05:44');

--create table 
create table reviews (
    id int identity(1,1) primary key,
    book_id int not null,
    reviewer_name nvarchar(100) not null,
    content nvarchar(500),
    rating int,
    published_date datetime,
    foreign key (book_id) references books(id)
);
--inserting values
insert into reviews (book_id, reviewer_name, content, rating, published_date) values
(1, 'john smith', 'my first review', 4, '2017-12-10 05:50:11'),
(2, 'john smith', 'my second review', 5, '2017-10-13 15:05:12'),
(2, 'alice walker', 'another review', 1, '2017-10-22 23:47:10');

--QUESTION 1
--fetch books written by authors whose name ends with er
select * from books where author like '%er';

--QUESTION2
-- display title, author, reviewer name (inner join)
select b.title,b.author,r.reviewer_name from books b
inner join 
reviews r on b.id = r.book_id;

--QUESTION3
select reviewer_name from reviews group by reviewer_name
having count(distinct book_id) > 1;

--QUESTION4
--creating customer table
create table customer (
    id int primary key,
    name nvarchar(50),
    age int,
    address nvarchar(50),
    salary decimal(10,2)
);
--inserting values 
insert into customer (id, name, age, address, salary) values
(1, 'ramesh', 32, 'ahmedabad', 2000.00),
(2, 'khilan', 25, 'delhi', 1500.00),
(3, 'kaushik', 23, 'kota', 2000.00),
(4, 'chaitali', 25, 'mumbai', 6500.00),
(5, 'hardik', 27, 'bhopal', 8500.00),
(6, 'komal', 22, 'mp', 4500.00),
(7, 'muffy', 24, 'indore', 10000.00);


--display names of customers who live at the same address and whose address contains character o anywhere
select name from customer where address like '%o%'and 
address in ( select address from customer group by address having count(*) > 1);



--QUESTION 5
--creating orders table
create table orders (
    oid int primary key,
    date datetime,
    customer_id int,
    amount decimal(10,2),
    foreign key (customer_id) references customer (id)
);

--inserting values
insert into orders (oid, date, customer_id, amount) values
(102, '2009-10-08 00:00:00', 3, 3000.00),
(100, '2009-10-08 00:00:00', 3, 1500.00),
(101, '2009-11-20 00:00:00', 2, 1560.00),
(103, '2008-05-20 00:00:00', 4, 2060.00);

--display date and total number of customers who placed order on the same date
select date,count( customer_id) as total_customers
from orders group by date;



--  QUESTION6
--create table employee
create table employee (
    id int primary key,
    name nvarchar(50),
    age int,
    address nvarchar(50),
    salary decimal(10,2)
);
--inserting values
insert into employee (id, name, age, address, salary) values
(1, 'Ramesh', 32, 'ahmedabad', 2000.00),
(2, 'Khilan', 25, 'delhi', 1500.00),
(3, 'Kaushik', 23, 'kota', 2000.00),
(4, 'Chaitali', 25, 'mumbai', 6500.00),
(5, 'Hardik', 27, 'bhopal', 8500.00),
(6, 'Komal', 22, 'mp', null),
(7, 'Muffy', 24, 'indore', null);

--display employee names in lower case whose salary is null
select lower(name) as name from employee where salary is null;



--QUESTION7
-- creating table
create table studentdetails (
    registerno int primary key,
    name nvarchar(50),
    age int,
    qualification nvarchar(20),
    mobileno bigint,
    mail_id nvarchar(100),
    location nvarchar(50),
    gender char(1)
);

--inserting values
insert into studentdetails
(registerno, name, age, qualification, mobileno, mail_id, location, gender) 
values
(2, 'sai', 22, 'b.e', 9952836777, 'sai@gmail.com', 'chennai', 'm'),
(3, 'kumar', 20, 'bsc', 7890125648, 'kumar@gmail.com', 'madurai', 'm'),
(4, 'selvi', 22, 'b.tech', 8904567342, 'selvi@gmail.com', 'salem', 'f'),
(5, 'nisha', 25, 'm.e', 7834672310, 'nisha@gmail.com', 'theni', 'f'),
(6, 'saisaran', 21, 'b.a', 7890345678, 'saran@gmail.com', 'madurai', 'f'),
(7, 'tom', 23, 'bca', 8901234675, 'tom@gmail.com', 'pune', 'm');


--display gender and total no of male and female
select gender, count(*) as total_count
from studentdetails
group by gender;
