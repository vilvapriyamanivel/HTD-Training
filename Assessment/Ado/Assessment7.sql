create database employeemanagement;
use employeemanagement;

 
--creating table
create table employee_details (
    empno int primary key,
    empname varchar(50) not null,
    empsal numeric(10,2) check (empsal >= 25000),
    emptype char(1) check (emptype in ('f','p'))
);
--Question1
--creating sp
go
create or alter procedure addemployee
    @empname varchar(50),
    @empsal numeric(10,2),
    @emptype char(1)
as
begin
    declare @newempno int;

    select @newempno = isnull(max(empno), 0) + 1 from employee_details;

    insert into employee_details (empno, empname, empsal, emptype)
    values (@newempno, @empname, @empsal, @emptype);
end;
go


--to test sp
exec addemployee 'ravi kumar', 30000, 'f';



--to display
select * from employee_details;



--Question2
-- Write a procedure that takes empid as input and outputs the updated salary as current salary + 100 for the given employee.
 
go
create or alter procedure updatesalary
    @empid int,
    @updatedsal numeric(10,2) output
as
begin
    update employee_details
    set empsal = empsal + 100
    where empno = @empid;

    select @updatedsal = empsal
    from employee_details
    where empno = @empid;
end;
go

--
go
create or alter procedure updatsalary
    @empid int
as
begin
    update employee_details
    set empsal = empsal + 100
    where empno = @empid;

    select empsal 
    from employee_details 
    where empno = @empid;
end;
go


--to test
declare @sal numeric(10,2);
exec updatesalary 1, @sal output;
select @sal as updated_salary;
--
exec updatsalary 1;

--display after updation
select * from employee_details
where empno = 1;

