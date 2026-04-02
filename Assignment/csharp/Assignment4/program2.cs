using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter a string :");
            string s = Console.ReadLine();
            if(s.Length<=1)
            {
                Console.WriteLine(s);
                return;
            }
            Console.WriteLine("String after swaping first and last Character is:");
            //way1
            char c= s[0];
            char d = s[s.Length - 1];
            string s2 =d.ToString();
            int i;
            for (i = 1; i < s.Length - 2; i++)
            {
                s2 += s[i];
            }
            s2 += s[i];
            s2 += c;
            Console.WriteLine(s2);
            //way2
            char[] carr = s.ToCharArray();

            char temp = carr[0];
            carr[0] = carr[carr.Length - 1];
            carr[carr.Length - 1] = temp;
             //string s3 = new string(carr);
            Console.WriteLine(new string(carr));




        }
    }
}
