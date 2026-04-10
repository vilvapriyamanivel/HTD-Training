using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        static void Main()
        {
            Console.Write("Enter the count of numbers: ");
            int count = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            Console.WriteLine("Enter the numbers:");

            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());
                numbers.Add(num);
            }

            var result = numbers
                .Select(n => new { Number = n, Square = n * n })
                .Where(x => x.Square > 20);

            Console.WriteLine("\nOutput:");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Number} - {item.Square}");
            }
        }
    
}
