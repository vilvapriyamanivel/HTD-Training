using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    
        class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public double Price { get; set; }
        }

        class Program2
        {
            static void Main(string[] args)
            {
                List<Product> products = new List<Product>();
                Console.Write("Enter Number Of Products: ");
                int numberOfProducts = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter details for products:\n");

                for (int i = 1; i <=numberOfProducts; i++)
                {
                    Product product = new Product();

                    Console.WriteLine($"Product {i}:");

                    Console.Write("Enter Product ID: ");
                    product.ProductId = int.Parse(Console.ReadLine());

                    Console.Write("Enter Product Name: ");
                    product.ProductName = Console.ReadLine();

                    Console.Write("Enter Product Price: ");
                    product.Price = double.Parse(Console.ReadLine());

                    products.Add(product);
                    Console.WriteLine();
                }

                // Sorting
                var sortedProducts = products.OrderBy(p => p.Price).ToList();

                Console.WriteLine("Products sorted by Price:\n");

                foreach (var p in sortedProducts)
                {
                    Console.WriteLine($"ID: {p.ProductId}, Name: {p.ProductName}, Price: {p.Price}");
                }

                
            }
        }
    
}
