-- using assignment2 table
--Assignment3
use Assignment2

--1. Retrieve a list of MANAGERS.
select * from emp where job = 'manager';


--2. Find out the names and salaries of all employees earning more than 1000 per 
--month. 
select ename, sal from emp where sal > 1000;


--3. Display the names and salaries of all employees except JAMES.
select ename, sal from emp where ename <> 'james';


--4. Find out the details of employees whose names begin with ‘S’.
select * from emp where ename like 's%';


--5. Find out the names of all employees that have ‘A’ anywhere in their name. 
select ename from emp where ename like '%a%';


--6. Find out the names of all employees that have ‘L’ as their third character in 
--their name. 
select ename from emp where ename like '__l%';


--7. Compute daily salary of JONES. 
select ename, sal/30 as daily_salary from emp where ename = 'jones';


--8. Calculate the total monthly salary of all employees. 
select sum(sal) as total_monthly_salary from emp;


--9. Print the average annual salary . 
select avg(sal * 12) as average_annual_salary from emp;


--10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30.
select ename, job, sal, deptno from emp where job <> 'salesman' and deptno = 30;

 
--11. List unique departments of the EMP table. 
select distinct deptno from emp;


--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ename as employee, sal as monthly_salary from emp where sal > 1500 and deptno in (10, 30);


--13. Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000. 
select ename, job, sal from emp where job in ('manager', 'analyst') and sal not in (1000, 3000, 5000);


--14. Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%. 
select ename, sal, [comm.] from emp where [comm.] > sal * 1.10;


--15. Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782. 
select ename from emp where ename like '%ll%'and (deptno = 30 or [mgr-id] = 7782);


--16. Display the names of employees with experience of over 30 years and under 40 yrs Count the total number of employees. 
select count(*) as total_employees from emp
where datediff(year, hiredate, getdate()) between 31 and 39;

--17. Retrieve the names of departments in ascending order and their employees in descending order. 
select d.dname, e.ename from dept d join emp e on d.deptno = e.deptno
order by d.dname asc, e.ename desc;


--18. Find out experience of MILLER. 
select ename,datediff(year, hiredate, getdate()) as experience_years
from emp where ename = 'miller';
