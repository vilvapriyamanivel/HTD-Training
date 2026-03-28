using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class jaggarrayandday
    {
        public static void Main(string[] args)
        {
            findday();
            arrange();
        }
        public static void arrange()
        {
            Console.Write("Enter a number:");
            int n=Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(i%2==0)
                    {
                        Console.Write("{0} ",n);
                    }
                    else
                    {
                        Console.Write("{0}",n);
                    }
                }
                Console.WriteLine();
            }



        }
        public static void findday()
        {
            Console.Write("Enter a number between 1 and 7:");
            int day = Convert.ToInt32(Console.ReadLine());
            day=day%7; 
            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Invalid input! Please enter a number between 1 and 7.");
                    break;
            }
        }
    }
}
