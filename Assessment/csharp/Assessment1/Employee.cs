using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem
{ 
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }
    
    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                DisplayMenu();
                Console.Write("Enter your choice: ");
                choice=Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        ViewAllEmployees();
                        break;
                    case 3:
                        SearchEmployee();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    case 6:
                        Console.WriteLine("Exiting program. Thank you!");
                        return;
                    

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            } while (choice != 6);
        }

        static void DisplayMenu()
        {
            Console.WriteLine("===== Employee Management Menu =====");
            Console.WriteLine("1. Add New Employee");
            Console.WriteLine("2. View All Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update Employee Details");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
            Console.WriteLine("====================================");
        }

        static void AddEmployee()
        {
            Employee emp = new Employee();

            Console.Write("Enter Employee ID: ");
            emp.Id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();

            Console.Write("Enter Salary: ");
            emp.Salary = double.Parse(Console.ReadLine());

            employees.Add(emp);
            Console.WriteLine("Employee added successfully.");
        }

        static void ViewAllEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees to display.");
                return;
            }

            Console.WriteLine("\nEmployee List:");
            foreach (var emp in employees)
            {
                DisplayEmployee(emp);
            }
        }

        static void SearchEmployee()
        {
            Console.Write("Enter Employee ID to search: ");
            int id = int.Parse(Console.ReadLine());
            Employee emp = null;

            foreach (Employee e in employees)
            {
                if (e.Id == id)
                {
                    emp = e;
                    break;
                }
            }

            if (emp == null)
                Console.WriteLine("Employee not found.");
            else
                DisplayEmployee(emp);
        }

        static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Employee emp = null;
            foreach (Employee e in employees)
            {
                if (e.Id == id)
                {
                    emp = e;
                    break;
                }
            }

            if (emp == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Console.Write("Enter new Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter new Department: ");
            emp.Department = Console.ReadLine();

            Console.Write("Enter new Salary: ");
            emp.Salary = double.Parse(Console.ReadLine());

            Console.WriteLine("Employee updated successfully.");
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            Employee emp = null;
            foreach (Employee e in employees)
            {
                if (e.Id == id)
                {
                    emp = e;
                    break;
                }
            }

            if (emp == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            employees.Remove(emp);
            Console.WriteLine("Employee deleted successfully.");
        }

        static void DisplayEmployee(Employee emp)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"ID        : {emp.Id}");
            Console.WriteLine($"Name      : {emp.Name}");
            Console.WriteLine($"Department: {emp.Department}");
            Console.WriteLine($"Salary    : {emp.Salary}");
            Console.WriteLine("-----------------------------------");
        }
    }
}