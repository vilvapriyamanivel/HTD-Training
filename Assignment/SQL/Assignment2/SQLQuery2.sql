create database Assignment2
use Assignment2


--create table dept
create table Dept (
    deptno int primary key,
    dname  varchar(20),
    loc    varchar(20)
);


--create table emp
create table Emp(
    empno    int primary key,
    ename    varchar(20),
    job      varchar(20),
    [mgr-id] int,
    hiredate date,
    sal      int,
    [comm.]  int,
    deptno   int,
    foreign key (deptno) references Dept(deptno)
);


--inserting data to dept table
insert into Dept (deptno, dname, loc) values
(10, 'Accounting', 'New York'),
(20, 'Research',   'Dallas'),
(30, 'Sales',      'Chicago'),
(40, 'Operations', 'Boston');


--inserting datas into empl table
insert into Emp (empno, ename, job, [mgr-id], hiredate, sal, [comm.], deptno) values
(7369, 'Smith',  'Clerk',     7902, convert(date,'17-12-1980',105),  800,  null, 20),
(7499, 'Allen',  'Salesman',  7698, convert(date,'20-02-1981',105), 1600,  300,  30),
(7521, 'Ward',   'Salesman',  7698, convert(date,'22-02-1981',105), 1250,  500,  30),
(7566, 'Jones',  'Manager',   7839, convert(date,'02-04-1981',105), 2975,  null, 20),
(7654, 'Martin', 'Salesman',  7698, convert(date,'28-09-1981',105), 1250, 1400,  30),
(7698, 'Blake',  'Manager',   7839, convert(date,'01-05-1981',105), 2850,  null, 30),
(7782, 'Clark',  'Manager',   7839, convert(date,'09-06-1981',105), 2450,  null, 10),
(7788, 'Scott',  'Analyst',   7566, convert(date,'19-04-1987',105), 3000,  null, 20),
(7839, 'King',   'President', null, convert(date,'17-11-1981',105), 5000,  null, 10),
(7844, 'Turner', 'Salesman',  7698, convert(date,'08-09-1981',105), 1500,    0,  30),
(7876, 'Adams',  'Clerk',     7788, convert(date,'23-05-1987',105), 1100,  null, 20),
(7900, 'James',  'Clerk',     7698, convert(date,'03-12-1981',105),  950,  null, 30),
(7902, 'Ford',   'Analyst',   7566, convert(date,'03-12-1981',105), 3000,  null, 20),
(7934, 'Miller', 'Clerk',     7782, convert(date,'23-01-1982',105), 1300,  null, 10);


--1. List all employees whose name begins with 'A'.
select * from Emp where ename like 'A%';


--2. Select all those employees who don't have a manager.
select * from Emp where [mgr-id] is null;


--3. List employee name, number, and salary for those earning 1200 to 1400
select ename, empno, sal from Emp where sal between 1200 and 1400;

--4.Give all employees in the RESEARCH department a 10% pay rise
--before update 
select e.* from Emp e join Dept d on e.deptno = d.deptno where d.dname = 'Research';

--after update
update Emp
set sal = sal * 1.10
where deptno = ( select deptno from Dept where dname = 'Research');


--5. Find the number of CLERKS employed (with descriptive heading)
select count(*) as Number_of_Clerks from Emp where job = 'Clerk';


--6. Find the average salary and number of employees for each job
select job,avg(sal) as Average_Salary,count(*) as Employee_Count from Emp group by job;


--7. List employees with the lowest and highest salary
select * from Emp where sal = (select min(sal) from Emp) or sal = (select max(sal) from Emp);


--8. List full details of departments that don’t have any employees
select d. * from Dept d
left join  Emp e on d.deptno = e.deptno where e.empno IS NULL;


--9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort by ascending name.
select ename, sal from Emp where job = 'Analyst' and sal > 1200 and deptno = 20 order by ename asc;


--10. For each department, list its name and number together with the total salary paid to employees in that department.
select d.deptno,d.dname,sum(e.sal) as Total_Salary from Dept d 
left join Emp e on d.deptno = e.deptno group by d.deptno, d.dname;


--11. Find out salary of both MILLER and SMITH.
select ename, sal from Emp where ename in ('Miller', 'Smith');


--12. Find out the names of the employees whose name begin with ‘A’ or ‘M’.
select ename from Emp where ename like 'A%' or ename like 'M%';


--13. Compute yearly salary of SMITH.
select ename,sal * 12 as Yearly_Salary from Emp where ename = 'Smith';


--14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850.
select ename, sal from Emp where sal not between 1500 and 2850;


--15. Find all managers who have more than 2 employees reporting to them.
select m.empno,m.ename,count(e.empno) as Number_of_Reportees from Emp m
join 
Emp e on m.empno = e.[mgr-id] group by m.empno, m.ename having count(e.empno) > 2;

