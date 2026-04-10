using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{

   
    class Program2
    {
        static void Main()
        {
            Console.Write("Enter the number of words: ");
            int count = int.Parse(Console.ReadLine());

            List<string> words = new List<string>();

            Console.WriteLine("Enter the words one by one:");

            for (int i = 0; i < count; i++)
            {
                words.Add(Console.ReadLine());
            }

            var result = words
                .Where(w => w.StartsWith("a") && w.EndsWith("m"));

            Console.WriteLine("\nOutput:");
            Console.WriteLine("The words that start with 'a' and end with 'm' :");
            if(!result.Any())
            {
                Console.WriteLine("No words found.");
            }
            else
            {
                foreach (var word in result)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
