using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelConcessionLibrary;

namespace Assignment7
{
    

    class Program4
    {
        // Constant Total Fare
        const decimal TotalFare = 500;

        static void Main()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            // Create object of class library class
            ConcessionCalculator calculator = new ConcessionCalculator();

            // Call class library method
            string result = calculator.CalculateConcession(age, TotalFare);

            Console.WriteLine("\nPassenger Name: " + name);
            Console.WriteLine(result);
        }
    }
}
