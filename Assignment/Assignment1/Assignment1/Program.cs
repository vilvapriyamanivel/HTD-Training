using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            //checkequal();
            //checktype();
        }
        public static void checkequal()
        {
            Console.Write("Input 1st Number:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input 2nd Number:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            if (n1 == n2)
            {
                Console.WriteLine("{0} and {1} are equal", n1, n2);
            }
            else
            {
                Console.WriteLine("{0} and {1} are equal", n1, n2);
            }
        }
        public static void checktype() {
            Console.Write("Enter a number to check its type:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            if (n1 == 0)
            {
                Console.WriteLine("{0} is a nutral number", n1);
            }
            else if (n1 >= 1) {
                Console.WriteLine("{0} is a positive number", n1);
            }
            else
            {
                Console.WriteLine("{0} is a negative number", n1);
            }
        }
    }
}
