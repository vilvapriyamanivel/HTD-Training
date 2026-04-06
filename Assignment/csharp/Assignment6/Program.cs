using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{


    public class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine("Book Name   : " + BookName);
            Console.WriteLine("Author Name : " + AuthorName);
            Console.WriteLine();
        }
    }
    public class BookShelf
    {
        private Books[] books = new Books[5];

        public Books this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }
    }
    public class BooksProgram
    {
        static void Main()
        {
            BookShelf shelf = new BookShelf();
            bool isEntered = false;

            Console.WriteLine("Enter your choice:");
            Console.WriteLine("1. Enter Book Details");
            Console.WriteLine("2. Display Book Details");
            Console.Write("Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"\nEnter details for Book {i + 1}");

                    Console.Write("Enter Book Name: ");
                    string bookName = Console.ReadLine();

                    Console.Write("Enter Author Name: ");
                    string authorName = Console.ReadLine();

                    shelf[i] = new Books(bookName, authorName);
                }
                isEntered = true;
                Console.WriteLine("\nBook details entered successfully.");
            }
            else if (choice == 2)
            {
                if (!isEntered)
                {
                    Console.WriteLine("\nNo books to display. Please enter book details first.");
                }
                else
                {
                    Console.WriteLine("\n--- Book Details ---\n");
                    for (int i = 0; i < 5; i++)
                    {
                        shelf[i].Display();
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }

}
