using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
        abstract class Student
        {
            public string Name { get; set; }
            public int StudentId { get; set; }
            public double Grade { get; set; }

            // Abstract method
            public abstract bool IsPassed(double grade);
        }

        // UG class
        class Undergraduate : Student
        {
            public override bool IsPassed(double grade)
            {
                return grade > 70.0;
            }
        }

        // Graduate class
        class Graduate : Student
        {
            public override bool IsPassed(double grade)
            {
                return grade > 80.0;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Choose Student Type:");
                Console.WriteLine("1. Undergraduate");
                Console.WriteLine("2. Graduate");
                Console.Write("Enter choice (1 or 2): ");

                int choice = int.Parse(Console.ReadLine());

                Student student;

                // Decide which object to create
                if (choice == 1)
                {
                    student = new Undergraduate();
                }
                else
                {
                    student = new Graduate();
                }

                // Getting Inputs
                Console.Write("Enter Student Name: ");
                student.Name = Console.ReadLine();

                Console.Write("Enter Student ID: ");
                student.StudentId = int.Parse(Console.ReadLine());

                Console.Write("Enter Grade: ");
                student.Grade = double.Parse(Console.ReadLine());

                // Display 
                Console.WriteLine("\nStudent Details:");
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"ID: {student.StudentId}");
                Console.WriteLine($"Grade: {student.Grade}");
                Console.WriteLine($"Passed: {student.IsPassed(student.Grade)}");

            }
        }
    
}
