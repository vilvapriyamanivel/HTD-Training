using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Program
    {
        //REmove the string character where the user wants to remove the character
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter a string :");
            string s= Console.ReadLine();
            Console.WriteLine(" Enter a character position you want to remove :");
            int pos = Convert.ToInt32(Console.ReadLine());

            if (pos >= 0 && pos < s.Length)
            {
                s = s.Remove(pos, 1);
                Console.WriteLine("String after removing character: " + s);
            }
            else
            {
                Console.WriteLine("Invalid position!");
            }
        }
    }
}
