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
            Console.Write("Input 1st Number:");
            int n1=Convert.ToInt32(Console.ReadLine());
            Console.Write("Input 2nd Number:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            if (n1 == n2)
            {
                Console.WriteLine("{0} and {1} are equal",n1,n2);
            }
            else {
                Console.WriteLine("{0} and {1} are equal",n1,n2);
                    }
        }
    }
}
