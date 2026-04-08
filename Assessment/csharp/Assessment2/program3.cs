using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
        class Program3
        {
            // Method that throws an exception if number is negative
            static void CheckNumber(int number)
            {
                if (number < 0)
                {
                    throw new ArgumentException("Number cannot be negative.");
                }

                Console.WriteLine("You  Entered: " + number);
            }

            static void Main(string[] args)
            {
                try
                {
                    Console.Write("Enter an integer: ");
                    int input = int.Parse(Console.ReadLine());

                    // method call
                    CheckNumber(input);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Exception caught: " + ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid integer.");
                }
                finally
                {
                    Console.WriteLine("Program execution completed.");
                }

                
            }
        }
    

}
