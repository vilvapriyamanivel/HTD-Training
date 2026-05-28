using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using miniproject.Services;

namespace miniproject
{
    class Program
    {
        

        //static int loggedInUserId = 0;
        static void Main(string[] args)
        {
            while (true)
            {
               
                    Console.Clear();

                    Console.WriteLine("========================================");
                    Console.WriteLine("     TRAIN RESERVATION SYSTEM");
                    Console.WriteLine("========================================");

                    Console.WriteLine("1. Admin");
                    Console.WriteLine("2. User");
                    Console.WriteLine("3. Exit");

                    Console.Write("Enter Choice : ");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AdminService.AdminLogin();
                            break;

                        case 2:
                            UserService.UserPanel();
                            break;

                        case 3:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
               

                Console.WriteLine("\nPress Any Key...");
                Console.ReadKey();
            }
        }




        
    }

}
