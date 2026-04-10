using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    

    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public decimal EmpSalary { get; set; }
    }

    class Program3
    {
        static void Main()
        {
            // Creating and populating employee list
            List<Employee> employees = new List<Employee>
        {
            new Employee { EmpId = 1, EmpName = "Arun", EmpCity = "Bangalore", EmpSalary = 50000 },
            new Employee { EmpId = 2, EmpName = "Kiran", EmpCity = "Chennai", EmpSalary = 42000 },
            new Employee { EmpId = 3, EmpName = "Manoj", EmpCity = "Bangalore", EmpSalary = 48000 },
            new Employee { EmpId = 4, EmpName = "Divya", EmpCity = "Hyderabad", EmpSalary = 55000 },
            new Employee { EmpId = 5, EmpName = "Anitha", EmpCity = "Bangalore", EmpSalary = 40000 }
        };

            // a. Display all employees
            Console.WriteLine("1. All Employees:");
            DisplayEmployees(employees);

            // b. Salary greater than 45000
            Console.WriteLine("\n2. Employees with Salary > 45000:");
            var highSalary = employees.Where(e => e.EmpSalary > 45000);
            DisplayEmployees(highSalary);

            // c. Employees from Bangalore
            Console.WriteLine("\n3. Employees from Bangalore:");
            var bangaloreEmployees = employees
                .Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase));
            DisplayEmployees(bangaloreEmployees);

            // d. Employees ordered by name (Ascending)
            Console.WriteLine("\n4. Employees ordered by Name (Ascending):");
            var sortedByName = employees.OrderBy(e => e.EmpName);
            DisplayEmployees(sortedByName);
        }

        // Common method to display employee data
        static void DisplayEmployees(IEnumerable<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"Id: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
            }
        }
    }
}
