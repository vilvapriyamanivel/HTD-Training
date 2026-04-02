using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class program3
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            Console.WriteLine("Enter the number of elements to push onto the stack:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter element {i + 1}:");
                int item = int.Parse(Console.ReadLine());
                stack.Push(item);
            }
            int[] a = stack.ToArray();
            Array.Sort(a);
            stack.Clear();
            Stack<int> stack2 = new Stack<int>(a);
            Console.WriteLine("Elements in the stack in descending:");
            foreach (int item in stack2)
            {
                Console.WriteLine(item);

            }
        }
    }
}
