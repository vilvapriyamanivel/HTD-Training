
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeApp
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>()
            {
                new Employee{ EmployeeID=1001, FirstName="Malcolm", LastName="Daruwalla", Title="Manager", DOB=new DateTime(1984,11,16), DOJ=new DateTime(2011,6,8), City="Mumbai"},
                new Employee{ EmployeeID=1002, FirstName="Asdin", LastName="Dhalla", Title="AsstManager", DOB=new DateTime(1984,8,20), DOJ=new DateTime(2012,7,7), City="Mumbai"},
                new Employee{ EmployeeID=1003, FirstName="Madhavi", LastName="Oza", Title="Consultant", DOB=new DateTime(1987,11,14), DOJ=new DateTime(2015,4,12), City="Pune"},
                new Employee{ EmployeeID=1004, FirstName="Saba", LastName="Shaikh", Title="SE", DOB=new DateTime(1990,6,3), DOJ=new DateTime(2016,2,2), City="Pune"},
                new Employee{ EmployeeID=1005, FirstName="Nazia", LastName="Shaikh", Title="SE", DOB=new DateTime(1991,3,8), DOJ=new DateTime(2016,2,2), City="Mumbai"},
                new Employee{ EmployeeID=1006, FirstName="Amit", LastName="Pathak", Title="Consultant", DOB=new DateTime(1989,11,7), DOJ=new DateTime(2014,8,8), City="Chennai"},
                new Employee{ EmployeeID=1007, FirstName="Vijay", LastName="Natrajan", Title="Consultant", DOB=new DateTime(1989,12,2), DOJ=new DateTime(2015,6,1), City="Mumbai"},
                new Employee{ EmployeeID=1008, FirstName="Rahul", LastName="Dubey", Title="Associate", DOB=new DateTime(1993,11,11), DOJ=new DateTime(2014,11,6), City="Chennai"},
                new Employee{ EmployeeID=1009, FirstName="Suresh", LastName="Mistry", Title="Associate", DOB=new DateTime(1992,8,12), DOJ=new DateTime(2014,12,3), City="Chennai"},
                new Employee{ EmployeeID=1010, FirstName="Sumit", LastName="Shah", Title="Manager", DOB=new DateTime(1991,4,12), DOJ=new DateTime(2016,1,2), City="Pune"}
            };

            // 1.Display a list of all the employee who have joined before 1/1/2015
            Console.WriteLine("1. Joined before 01/01/2015");
            empList.Where(e => e.DOJ < new DateTime(2015, 1, 1))
                   .ToList()
                   .ForEach(e => Console.WriteLine(e.FirstName + " " + e.LastName));

            // 2. Display a list of all the employee whose date of birth is after 1/1/1990
            Console.WriteLine("\n2. DOB after 01/01/1990");
            empList.Where(e => e.DOB > new DateTime(1990, 1, 1))
                   .ToList()
                   .ForEach(e => Console.WriteLine(e.FirstName + " " + e.LastName));

            // 3. Display a list of all the employee whose designation is Consultant and Associate
            Console.WriteLine("\n3. Consultant and Associate");
            empList.Where(e => e.Title == "Consultant" || e.Title == "Associate")
                   .ToList()
                   .ForEach(e => Console.WriteLine(e.FirstName + " " + e.LastName));

            // 4. Display total number of employees
            Console.WriteLine("\n4. Total Employees: " + empList.Count());

            // 5. Display total number of employees belonging to “Chennai”
            Console.WriteLine("\n5. Employees in Chennai: " +
                              empList.Count(e => e.City == "Chennai"));

            // 6.Display highest employee id from the list
            Console.WriteLine("\n6. Highest Employee ID: " +
                              empList.Max(e => e.EmployeeID));

            // 7.Display total number of employee who have joined after 1/1/2015
            Console.WriteLine("\n7. Joined after 01/01/2015: " +
                              empList.Count(e => e.DOJ > new DateTime(2015, 1, 1)));

            // 8.Display total number of employee whose designation is not “Associate”
            Console.WriteLine("\n8. Not Associate: " +
                              empList.Count(e => e.Title != "Associate"));

            // 9. Display total number of employee based on City
            Console.WriteLine("\n9. Employees based on City");
            empList.GroupBy(e => e.City)
                   .ToList()
                   .ForEach(g => Console.WriteLine(g.Key + " : " + g.Count()));

            // 10. Display total number of employee based on city and title
            Console.WriteLine("\n10. Employees based on City and Title");
            empList.GroupBy(e => new { e.City, e.Title })
                   .ToList()
                   .ForEach(g =>
                       Console.WriteLine($"{g.Key.City} - {g.Key.Title} : {g.Count()}"));

            // 11.Display total number of employee who is youngest in the list
            DateTime youngestDob = empList.Max(e => e.DOB);
            Console.WriteLine("\n11. Youngest Employee(s)");
            empList.Where(e => e.DOB == youngestDob)
                   .ToList()
                   .ForEach(e => Console.WriteLine(e.FirstName + " " + e.LastName));

            Console.ReadLine();
        }
    }
}