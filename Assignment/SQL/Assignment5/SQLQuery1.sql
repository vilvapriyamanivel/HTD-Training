use Assignment2
select * from emp
/*1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

   a) HRA as 10% of Salary
   b) DA as 20% of Salary
   c) PF as 8% of Salary
   d) IT as 5% of Salary
   e) Deductions as sum of PF and IT
   f) Gross Salary as sum of Salary, HRA, DA
   g) Net Salary as Gross Salary - Deductions

Print the payslip neatly with all details*/

create or alter proc sp_generatepayslip @empno int
as
begin
    declare
        @ename varchar(20),
        @sal decimal(10,2),
        @hra decimal(10,2),
        @da decimal(10,2),
        @pf decimal(10,2),
        @it decimal(10,2),
        @deductions decimal(10,2),
        @grosssalary decimal(10,2),
        @netsalary decimal(10,2)

    select
        @ename = ename,
        @sal = sal
    from emp
    where empno = @empno

    if @sal is null
    begin
        print 'invalid employee number'
        return
    end

    set @hra = @sal * 0.10
    set @da = @sal * 0.20
    set @pf = @sal * 0.08
    set @it = @sal * 0.05

    set @deductions = @pf + @it
    set @grosssalary = @sal + @hra + @da
    set @netsalary = @grosssalary - @deductions

    print '---------------------------------------'
    print '               payslip                '
    print '---------------------------------------'
    print 'employee no   : ' + cast(@empno as varchar)
    print 'employee name : ' + @ename
    print '---------------------------------------'
    print 'basic salary  : ' + cast(@sal as varchar)
    print 'hra (10%)     : ' + cast(@hra as varchar)
    print 'da (20%)      : ' + cast(@da as varchar)
    print '---------------------------------------'
    print 'gross salary  : ' + cast(@grosssalary as varchar)
    print '---------------------------------------'
    print 'pf (8%)       : ' + cast(@pf as varchar)
    print 'it (5%)       : ' + cast(@it as varchar)
    print 'deductions    : ' + cast(@deductions as varchar)
    print '---------------------------------------'
    print 'net salary    : ' + cast(@netsalary as varchar)
    print '---------------------------------------'
end

exec sp_generatepayslip 7369


--2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc
--Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details. try to match the dates and stop manipulation 
go
create table holiday
(
    holiday_date date primary key,
    holiday_name varchar(50)
)

insert into holiday values
('2026-01-26','republic day'),
('2026-08-15','independence day'),
('2026-10-31','diwali'),
('2026-12-25','christmas')


insert into holiday values
(cast(getdate() as date), 'justleave')



create or alter trigger trg_emp_holidayrestrict
on emp
for insert, update, delete
as
begin
    declare @holidayname varchar(50)

    select @holidayname = holiday_name
    from holiday
    where holiday_date = cast(getdate() as date)

    if @holidayname is not null
    begin
        raiserror(
            'due to %s you cannot manipulate data',
            16,
            1,
            @holidayname
        )
        rollback transaction
        return
    end
end

update emp set sal = sal + 500 where empno = 7369

insert into emp(empno,ename,job,hiredate,sal,deptno)
values(8009,'rajesh','clerk',getdate(),1200,20)

delete from emp where empno = 7900
