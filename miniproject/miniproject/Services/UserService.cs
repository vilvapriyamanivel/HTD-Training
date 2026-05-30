using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using miniproject.Database;
using System.Threading.Tasks;

namespace miniproject.Services
{
    public class UserService
    {
        public static int loggedInUserId = 0;
        //user panel
        public static void UserPanel()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Back");

                Console.Write("Enter Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterUser();
                        break;

                    case 2:
                        UserLogin();
                        break;

                    case 3:
                        return;
                }

                Console.ReadKey();
            }
        }
        //register user
        public static void RegisterUser()
        {
            try
            {
                Console.Clear();

                Console.Write("Enter Username : ");
                string username = Console.ReadLine();

                Console.Write("Enter Password : ");
                string password = Console.ReadLine();

                SqlConnection con =
                new SqlConnection(DbConfig.ConnectionString);

                string checkQuery =
                "SELECT COUNT(*) FROM Users WHERE Username=@Username";

                SqlCommand checkCmd =
                new SqlCommand(checkQuery, con);

                checkCmd.Parameters.AddWithValue("@Username", username);

                con.Open();

                int exists =
                Convert.ToInt32(checkCmd.ExecuteScalar());

                if (exists > 0)
                {
                    Console.WriteLine("Username Already Exists");
                    con.Close();
                    return;
                }

                string query =
                @"INSERT INTO Users
            VALUES(@Username,@Password,'User')";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                cmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine("Account Created Successfully");
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
        //user login
        public static void UserLogin()
        {
            try
            {
                Console.Clear();

                Console.Write("Enter Username : ");
                string username = Console.ReadLine();

                Console.Write("Enter Password : ");
                string password = Console.ReadLine();

                SqlConnection con =
                new SqlConnection(DbConfig.ConnectionString);

                string query =
                @"SELECT UserId
            FROM Users
            WHERE Username=@Username
            AND Password=@Password
            AND RoleName='User'";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();

                object result =
                cmd.ExecuteScalar();

                if (result != null)
                {
                    loggedInUserId =
                    Convert.ToInt32(result);

                    Console.WriteLine("Login Successful");

                    UserMenu();
                }
                else
                {
                    Console.WriteLine("Invalid Username Or Password");
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
        static void UserMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("==================================");
                Console.WriteLine("             USER MENU");
                Console.WriteLine("==================================");

                Console.WriteLine("1. Search Trains");
                Console.WriteLine("2. Book Ticket");
                Console.WriteLine("3. Cancel Ticket");
                Console.WriteLine("4. View My Bookings");
                Console.WriteLine("5. Logout");

                Console.Write("Enter Choice : ");

                int choice =
                Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        TrainService.SearchTrains();
                        break;

                    case 2:
                        BookingService.BookTicket();
                        break;

                    case 3:
                        BookingService.CancelPassenger();
                        break;

                    case 4:
                        BookingService.ViewBookings();
                        break;

                    case 5:
                        return;
                }

                Console.ReadKey();
            }
        }

    }
}