using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{

    
        class Program4
        {
            // Delegate declaration
            public delegate int CalculatorDelegate(int a, int b);

            // Calculator methods
            static int Add(int a, int b)
            {
                return a + b;
            }

            static int Subtract(int a, int b)
            {
                return a - b;
            }

            static int Multiply(int a, int b)
            {
                return a * b;
            }

            // Method that accepts delegate as argument
            static void PerformOperation(string operationName, CalculatorDelegate operation, int x, int y)
            {
                int result = operation(x, y);
                Console.WriteLine($"{operationName}: {result}");
            }

            static void Main(string[] args)
            {
                // Input from user
                Console.Write("Enter first integer: ");
                int num1 = int.Parse(Console.ReadLine());

                Console.Write("Enter second integer: ");
                int num2 = int.Parse(Console.ReadLine());

                Console.WriteLine("\nCalculator Results:");

                // Passing delegate objects
                PerformOperation("Addition", Add, num1, num2);
                PerformOperation("Subtraction", Subtract, num1, num2);
                PerformOperation("Multiplication", Multiply, num1, num2);

                Console.ReadLine();
            }
        }
    }