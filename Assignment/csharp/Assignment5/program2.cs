using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
        
        public class InvalidMarksException : ApplicationException
        {
            public InvalidMarksException(string message) : base(message)
            {
            }
        }
        public class Scholarship
        {
            public double Merit(double marks, double fees)
            {
                if (marks >= 70 && marks <= 80)
                {
                    return fees * 0.20;
                }
                else if (marks > 80 && marks <= 90)
                {
                    return fees * 0.30;
                }
                else if (marks > 90)
                {
                    return fees * 0.50;
                }
                else
                {
                    throw new InvalidMarksException("Scholarship not applicable for marks below 70.");
                }
            }
        }
        public class program2
        {
            static void Main()
            {
                try
                {
                    Console.Write("Enter marks: ");
                    double marks = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter fees: ");
                    double fees = Convert.ToDouble(Console.ReadLine());

                    Scholarship scholarship = new Scholarship();
                    double amount = scholarship.Merit(marks, fees);

                    Console.WriteLine("Scholarship Amount: " + amount);
                }
                catch (InvalidMarksException ex)
                {
                    Console.WriteLine("User Exception: " + ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter numeric values only.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Scholarship calculation completed.");
                }
            }
        }
    }

