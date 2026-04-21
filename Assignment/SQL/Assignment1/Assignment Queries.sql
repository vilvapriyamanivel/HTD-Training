create database Assignment
use  Assignment



--creating clients table
create table Clients (
    Client_ID int PRIMARY KEY,
    Cname varchar(40) NOT NULL,
    Address varchar(30),
    Email varchar(30) UNIQUE,
    Phone bigint,
    Business varchar(20) NOT NULL
);



--creating departments table
create table Departments (
    Deptno int PRIMARY KEY,
    Dname varchar(15) NOT NULL,
    Loc varchar(20)
);




--creating employees table
create table Employees (
    Empno int PRIMARY KEY,
    Ename varchar(20) NOT NULL,
    Job varchar(15),
    Salary decimal(7,2) CHECK (Salary > 0),
    Deptno int,
    CONSTRAINT fk_emp_dept 
        FOREIGN KEY (Deptno) REFERENCES Departments(Deptno)
);



--creating projects table
create table Projects (
    Project_ID int PRIMARY KEY,
    Descr varchar NOT NULL,
    Start_Date DATE,
    Planned_End_Date DATE,
    Actual_End_Date DATE,
    Budget decimal(10,2) CHECK (Budget > 0),
    Client_ID int,
    CONSTRAINT fk_proj_client 
        FOREIGN KEY (Client_ID) REFERENCES Clients(Client_ID),
    CONSTRAINT chk_dates 
        CHECK (Actual_End_Date IS NULL OR Actual_End_Date > Planned_End_Date)
);



--creating empproject tasks table
create table EmpProjectTasks (
    Project_ID int,
    Empno int,
    Start_Date DATE,
    End_Date DATE,
    Task varchar(25) NOT NULL,
    Status varchar(15) NOT NULL,
    CONSTRAINT pk_ept PRIMARY KEY (Project_ID, Empno),
    CONSTRAINT fk_ept_proj 
        FOREIGN KEY (Project_ID) REFERENCES Projects(Project_ID),
    CONSTRAINT fk_ept_emp 
        FOREIGN KEY (Empno) REFERENCES Employees(Empno)
);



--add datas for clients table
insert into Clients values (1001,'ACME Utilities','Noida','contact@acmeutil.com',9567880032,'Manufacturing');
insert into Clients values (1002,'Trackon Consultants','Mumbai','consult@trackon.com',8734210090,'Consultant');
insert into Clients values (1003,'MoneySaver Distributors','Kolkata','save@moneysaver.com',7799886655,'Reseller');
insert into Clients values (1004,'Lawful Corp','Chennai','justice@lawful.com',9210342219,'Professional');



--add datas for departments table
insert into Departments values (10,'Design','Pune');
insert into Departments values (20,'Development','Pune');
insert into Departments values (30,'Testing','Mumbai');
insert into Departments values (40,'Document','Mumbai');



--add datas for employees table
insert into Employees values (7001,'Sandeep','Analyst',25000,10),
 (7002,'Rajesh','Designer',30000,10),
 (7003,'Madhav','Developer',40000,20),
 (7004,'Manoj','Developer',40000,20),
 (7005,'Abhay','Designer',35000,10),
 (7006,'Uma','Tester',30000,30),
 (7007,'Gita','Tech. Writer',30000,40),
 (7008,'Priya','Tester',35000,30),
 (7009,'Nutan','Developer',45000,20),
 (7010,'Smita','Analyst',20000,10),
 (7011,'Anand','Project Mgr',65000,10);

 

 --add datas for projects table
 insert into Projects values(401,'Inventory',convert(DATE,'01-04-2011',105),convert(DATE,'01-10-2011',105),convert(DATE,'31-10-2011',105),150000,1001),
  (402,'Accounting',convert(DATE,'01-08-2011',105),convert(DATE,'01-01-2012',105),NULL,500000,1002),
  (403,'Payroll',convert(DATE,'01-10-2011',105),convert(DATE,'31-12-2011',105),NULL,75000,1003),
  (404,'Contact Mgmt',convert(DATE,'01-11-2011',105),convert(DATE,'31-12-2011',105),NULL,50000,1004);



  --add datas for empproject tasks table
 insert into EmpProjectTasks(Project_ID, Empno, Start_Date, End_Date, Task, Status)values
(401,7001,convert(DATE,'01-04-2011',105),convert(DATE,'20-04-2011',105),'System Analysis','Completed'),
(401,7002,convert(DATE,'21-04-2011',105),convert(DATE,'30-05-2011',105),'System Design','Completed'),
(401,7003,convert(DATE,'01-06-2011',105),convert(DATE,'15-07-2011',105),'Coding','Completed'),
(401,7004,convert(DATE,'18-07-2011',105),convert(DATE,'01-09-2011',105),'Coding','Completed'),
(401,7006,convert(DATE,'03-09-2011',105),convert(DATE,'15-09-2011',105),'Testing','Completed'),
(401,7009,convert(DATE,'18-09-2011',105),convert(DATE,'05-10-2011',105),'Code Change','Completed'),
(401,7008,convert(DATE,'06-10-2011',105),convert(DATE,'16-10-2011',105),'Testing','Completed'),
(401,7007,convert(DATE,'06-10-2011',105),convert(DATE,'22-10-2011',105),'Documentation','Completed'),
(401,7011,convert(DATE,'22-10-2011',105),convert(DATE,'31-10-2011',105),'Sign off','Completed'),
(402,7010,convert(DATE,'01-08-2011',105),convert(DATE,'20-08-2011',105),'System Analysis','Completed'),
(402,7002,convert(DATE,'22-08-2011',105),convert(DATE,'30-09-2011',105),'System Design','Completed'),
(402,7004,convert(DATE,'01-10-2011',105),NULL,'Coding','In Progress');


/*SELECT * FROM Clients;
SELECT * FROM Departments;
SELECT * FROM Employees;
SELECT * FROM Projects;
SELECT * FROM EmpProjectTasks;*/