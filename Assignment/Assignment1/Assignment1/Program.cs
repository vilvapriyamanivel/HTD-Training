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
            checkequal();
            checktype();
            arithmeticoperations();
            multiplicationtable();
            Program1 program = new Program1();
            program.triplesum();
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
                Console.WriteLine("{0} and {1} are not equal", n1, n2);
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
        static void arithmeticoperations()
        {
            Console.Write("Input number1:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input operation:");
            char op = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.Write("Input number2:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case '+':
                    Console.WriteLine("{0} {1} {2} = {3}", n1, op, n2, n1 + n2);
                    break;
                case '-':
                    Console.WriteLine("{0} {1} {2} = {3}", n1, op, n2, n1 - n2);
                    break;
                case '*':
                    Console.WriteLine("{0} {1} {2} = {3}", n1, op, n2, n1 * n2);
                    break;
                case '/':
                    Console.WriteLine("{0} {1} {2} = {3}", n1, op, n2, n1 / n2);
                    break;
                default:
                    Console.WriteLine(" Enter a valid operation");
                    break;

            }
        }
            public static void multiplicationtable()
            {
            Console.Write("Enter a Number:");
            int n1= Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<=10;i++)
            {
                Console.WriteLine("{0} * {1} ={2}",n1,i,n1*i);
            }


            }
        public  void triplesum()
        {
            Console.Write("Input 1st Number:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input 2nd Number:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            if (n1 == n2)
            {
                Console.WriteLine("{0} and {1} are equal so the sum will be {2}", n1, n2,n1+n1+n1);
            }
            else
            {
                Console.WriteLine("{0} and {1} are not equal so the sum will be {2}", n1, n2,n1+n2);
            }
        }




    }
    }

