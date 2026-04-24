--Assignment4
--1.Write a T-SQL Program to find the factorial of a given number.
create database Assignment4
use Assignment4;
declare @num int = 5;
declare @fact bigint = 1;
declare @i int = 1;

while @i <= @num
begin
    set @fact = @fact * @i;
    set @i = @i + 1;
end

print 'factorial of ' + cast(@num as varchar) + ' is ' + cast(@fact as varchar);

--2.Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 
go
create procedure sp_multiplicationtable(@num int,@limit int)
as
begin
    declare @i int = 1;
    while @i <= @limit
    begin
        print cast(@num as varchar(10)) + ' x '
            + cast(@i as varchar(10)) + ' = '
            + cast(@num * @i as varchar(10));
        set @i = @i + 1;
    end
end;

--executing 
exec sp_multiplicationtable 5, 10;


--3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly
--creating student table
create table student
(sid int primary key,
    sname varchar(20));

--creating mark table
create table marks
(  mid int primary key,
    sid int,
    score int);
 --Inserting
 
 insert into student values(1,'jack'),
(2,'rithvik'),
(3,'jaspreeth'),
(4,'praveen'),
(5,'bisa'),
(6,'suraj');

insert into marks values
(1,1,23),
(2,6,95),
(3,4,98),
(4,2,17),
(5,3,53),
(6,5,13);


--creating function to display student status 

create function fn_studentstatus (@score int)
returns varchar(10)
as
begin
    declare @status varchar(10);

    if @score >= 50
        set @status = 'pass';
    else
        set @status = 'fail';

    return @status;
end;

-- to execute 

select s.sid,s.sname,m.score,
dbo.fn_studentstatus(m.score) as status from student s
join marks m on s.sid = m.sid;




