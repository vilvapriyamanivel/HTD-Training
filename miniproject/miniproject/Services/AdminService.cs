using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miniproject.Database;
namespace miniproject.Services
{
   public  class AdminService
    {
        //admin login
        public static void AdminLogin()
        {
            try
            {
                Console.Clear();

                Console.Write("Enter Admin Username : ");
                string username = Console.ReadLine();

                Console.Write("Enter Password : ");
                string password = Console.ReadLine();

                SqlConnection con =
                new SqlConnection(DbConfig.ConnectionString);

                string query =
                @"SELECT COUNT(*)
            FROM Users
            WHERE Username=@Username
            AND Password=@Password
            AND RoleName='Admin'";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();

                int count =
                Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    Console.WriteLine("Admin Login Successful");

                    AdminMenu();
                }
                else
                {
                    Console.WriteLine("Invalid Admin Credentials");
                }

                con.Close();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input Format");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }
        //admin menu
       public  static void AdminMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("==================================");
                Console.WriteLine("            ADMIN MENU");
                Console.WriteLine("==================================");

                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. View Trains");
                Console.WriteLine("3. Delete Train");
                Console.WriteLine("4. View All Bookings");
                Console.WriteLine("5. Logout");

                Console.Write("Enter Choice : ");

                int choice =
                Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        TrainService.AddTrain();
                        break;

                    case 2:
                        TrainService.ViewTrains();
                        break;

                    case 3:
                        TrainService.DeleteTrain();
                        break;

                    case 4:
                        BookingService.ViewAllBookings();
                        break;

                    case 5:
                        return;
                }

                Console.ReadKey();
            }
        }

    }
}
