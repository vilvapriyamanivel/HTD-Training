using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miniproject.Models;
using miniproject.Database;

namespace miniproject.Services
{
    public class BookingService
    {
        // BOOK TICKET

        public static void BookTicket()
        {
            try
            {
                TrainService.ViewTrains(); 

                Console.Write("Enter Train No : ");

                int trainNo =
                Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Travel Date : ");

                DateTime travelDate =
                Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("\n1. 2AC");
                Console.WriteLine("2. 3AC");
                Console.WriteLine("3. Sleeper");

                Console.Write("Choose Class : ");

                int classChoice =
                Convert.ToInt32(Console.ReadLine());

                string travelClass = "";
                string seatColumn = "";
                string chargeColumn = "";

                if (classChoice == 1)
                {
                    travelClass = "2AC";
                    seatColumn = "Available2ACSeats";
                    chargeColumn = "Charge2AC";
                }
                else if (classChoice == 2)
                {
                    travelClass = "3AC";
                    seatColumn = "Available3ACSeats";
                    chargeColumn = "Charge3AC";
                }
                else
                {
                    travelClass = "Sleeper";
                    seatColumn = "AvailableSleeperSeats";
                    chargeColumn = "ChargeSleeper";
                }

                Console.Write("Passenger Count(Max 3) : ");

                int passengerCount =
                Convert.ToInt32(Console.ReadLine());

                SqlConnection con =
                new SqlConnection(DbConfig.ConnectionString);
                con.Open();
                if (passengerCount > 3)
                {
                    Console.WriteLine("Maximum 3 Tickets Allowed");
                    con.Close();
                    return;
                }


                string query =
                $"SELECT {seatColumn},{chargeColumn} FROM Trains WHERE TrainNo=@TrainNo";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@TrainNo", trainNo);

                SqlDataReader dr =
                cmd.ExecuteReader();

                dr.Read();
                if (!dr.Read())
                {
                    Console.WriteLine("Invalid Train Number");
                    dr.Close();
                    con.Close();
                    return;
                }
                int availableSeats =
                Convert.ToInt32(dr[seatColumn]);

                decimal charge =
                Convert.ToDecimal(dr[chargeColumn]);

                dr.Close();

                string bookingType = "Confirmed";

                if (availableSeats < passengerCount)
                {
                    bookingType = "Waiting";

                    Console.WriteLine(
                    "\nSeats Not Available");

                    Console.WriteLine(
                    "Booking Added To Waiting List");
                }

                decimal amount =
                passengerCount * charge;

                string bookingQuery =
                @"INSERT INTO Bookings
    (
        TravelDate,
        UserId,
        TrainNo,
        TravelClass,
        PassengerCount,
        Amount,
        BookingType
    )
    VALUES
    (
        @TravelDate,
        @UserId,
        @TrainNo,
        @TravelClass,
        @PassengerCount,
        @Amount,
        @BookingType
    )";

                SqlCommand bookingCmd =
                new SqlCommand(bookingQuery, con);

                bookingCmd.Parameters.AddWithValue("@TravelDate", travelDate);
                bookingCmd.Parameters.AddWithValue("@UserId", UserService.loggedInUserId);
                bookingCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                bookingCmd.Parameters.AddWithValue("@TravelClass", travelClass);
                bookingCmd.Parameters.AddWithValue("@PassengerCount", passengerCount);
                bookingCmd.Parameters.AddWithValue("@Amount", amount);
                bookingCmd.Parameters.AddWithValue("@BookingType", bookingType);

                bookingCmd.ExecuteNonQuery();

                SqlCommand idCmd =
                new SqlCommand(
                "SELECT MAX(BookingId) FROM Bookings", con);

                int bookingId =
                Convert.ToInt32(idCmd.ExecuteScalar());

                for (int i = 1; i <= passengerCount; i++)
                {
                    Console.WriteLine("\nPassenger " + i);

                    Console.Write("Name : ");
                    string name = Console.ReadLine();

                    Console.Write("Age : ");
                    int age =
                    Convert.ToInt32(Console.ReadLine());

                    Console.Write("Gender : ");
                    string gender =
                    Console.ReadLine();

                    Console.Write("Phone Number : ");
                    string phone =
                    Console.ReadLine();

                    string seatNo = "Waiting";

                    if (bookingType == "Confirmed")
                    {
                        if (travelClass == "2AC")
                        {
                            seatNo =
                            "A" + new Random().Next(1, 50);
                        }
                        else if (travelClass == "3AC")
                        {
                            seatNo =
                            "B" + new Random().Next(1, 100);
                        }
                        else
                        {
                            seatNo =
                            "S" + new Random().Next(1, 150);
                        }
                    }

                    Console.WriteLine(
                    "Seat Number : " + seatNo);

                    string passQuery =
                    @"INSERT INTO Passengers
        (
            BookingId,
            PassengerName,
            Age,
            Gender,
            PhoneNumber,
            SeatNumber
        )
        VALUES
        (
            @BookingId,
            @PassengerName,
            @Age,
            @Gender,
            @PhoneNumber,
            @SeatNumber
        )";

                    SqlCommand passCmd =
                    new SqlCommand(passQuery, con);

                    passCmd.Parameters.AddWithValue("@BookingId", bookingId);
                    passCmd.Parameters.AddWithValue("@PassengerName", name);
                    passCmd.Parameters.AddWithValue("@Age", age);
                    passCmd.Parameters.AddWithValue("@Gender", gender);
                    passCmd.Parameters.AddWithValue("@PhoneNumber", phone);
                    passCmd.Parameters.AddWithValue("@SeatNumber", seatNo);

                    passCmd.ExecuteNonQuery();
                }

                if (bookingType == "Confirmed")
                {
                    string updateSeats =
                    $"UPDATE Trains SET {seatColumn}={seatColumn}-@Count WHERE TrainNo=@TrainNo";

                    SqlCommand updateCmd =
                    new SqlCommand(updateSeats, con);

                    updateCmd.Parameters.AddWithValue("@Count", passengerCount);
                    updateCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                    updateCmd.ExecuteNonQuery();
                }

                con.Close();

                Console.WriteLine("\nBooking Successful");
                Console.WriteLine("Booking ID : " + bookingId);
                Console.WriteLine("Booking Type : " + bookingType);
                Console.WriteLine("Total Amount : " + amount);
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

        // VIEW BOOKINGS

        public static void ViewBookings()
        {
            SqlConnection con =
            new SqlConnection(DbConfig.ConnectionString);

            string query =
            @"SELECT *
    FROM Bookings
    WHERE UserId=@UserId";

            SqlCommand cmd =
            new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@UserId", UserService.loggedInUserId);

            con.Open();

            SqlDataReader dr =
            cmd.ExecuteReader();

            bool hasBookings = false;

            while (dr.Read())
            {
                hasBookings = true;

                Console.WriteLine("================================");

                Console.WriteLine(
                "Booking ID : " +
                dr["BookingId"]);

                Console.WriteLine(
                "Train No : " +
                dr["TrainNo"]);

                Console.WriteLine(
                "Travel Class : " +
                dr["TravelClass"]);

                Console.WriteLine(
                "Travel Date : " +
                Convert.ToDateTime(
                dr["TravelDate"]).ToShortDateString());

                Console.WriteLine(
                "Passengers : " +
                dr["PassengerCount"]);

                Console.WriteLine(
                "Amount : " +
                dr["Amount"]);

                Console.WriteLine(
                "Booking Status : " +
                dr["BookingStatus"]);

                Console.WriteLine(
                "Booking Type : " +
                dr["BookingType"]);

                Console.WriteLine("================================");
            }

            if (!hasBookings)
            {
                Console.WriteLine("\nNo Tickets Booked Yet");
            }

            con.Close();
        }

        // VIEW ALL BOOKINGS

        public static void ViewAllBookings()
        {
            Console.Clear();

            SqlConnection con =
            new SqlConnection(DbConfig.ConnectionString);

            string query =
            @"SELECT
    B.BookingId,
    U.Username,
    B.TrainNo,
    B.TravelDate,
    B.TravelClass,
    B.PassengerCount,
    B.Amount,
    B.BookingStatus,
    B.BookingType
    FROM Bookings B
    INNER JOIN Users U
    ON B.UserId=U.UserId";

            SqlCommand cmd =
            new SqlCommand(query, con);

            con.Open();

            SqlDataReader dr =
            cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("================================");

                Console.WriteLine(
                "Booking ID : " +
                dr["BookingId"]);

                Console.WriteLine(
                "Username : " +
                dr["Username"]);

                Console.WriteLine(
                "Train No : " +
                dr["TrainNo"]);

                Console.WriteLine(
                "Travel Date : " +
                Convert.ToDateTime(
                dr["TravelDate"]).ToShortDateString());

                Console.WriteLine(
                "Class : " +
                dr["TravelClass"]);

                Console.WriteLine(
                "Passengers : " +
                dr["PassengerCount"]);

                Console.WriteLine(
                "Amount : " +
                dr["Amount"]);

                Console.WriteLine(
                "Booking Status : " +
                dr["BookingStatus"]);

                Console.WriteLine(
                "Booking Type : " +
                dr["BookingType"]);

                Console.WriteLine("================================");
            }

            con.Close();
        }

        // CANCEL TICKET

        public static void CancelTicket()
        {
            try
            {
                ViewBookings();

                Console.Write("Enter Booking ID : ");

                int bookingId =
                Convert.ToInt32(Console.ReadLine());

                SqlConnection con =
                new SqlConnection(DbConfig.ConnectionString);

                con.Open();

                string query =
                @"SELECT *
    FROM Bookings
    WHERE BookingId=@BookingId
AND UserId=@UserId
AND BookingStatus='Active'";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@BookingId", bookingId);
                cmd.Parameters.AddWithValue("@UserId", UserService.loggedInUserId);

                SqlDataReader dr =
                cmd.ExecuteReader();

                if (!dr.Read())
                {
                    Console.WriteLine("Invalid Booking ID");
                    con.Close();
                    return;
                }

                int trainNo =
                Convert.ToInt32(dr["TrainNo"]);

                int passengerCount =
                Convert.ToInt32(dr["PassengerCount"]);

                decimal amount =
                Convert.ToDecimal(dr["Amount"]);

                string travelClass =
                dr["TravelClass"].ToString();

                dr.Close();

                decimal refund =
                amount * 0.9m;

                string cancelQuery =
                @"INSERT INTO Cancellations
    (BookingId,RefundAmount)
    VALUES
    (@BookingId,@RefundAmount)";

                SqlCommand cancelCmd =
                new SqlCommand(cancelQuery, con);

                cancelCmd.Parameters.AddWithValue("@BookingId", bookingId);
                cancelCmd.Parameters.AddWithValue("@RefundAmount", refund);

                cancelCmd.ExecuteNonQuery();

                string updateBooking =
                @"UPDATE Bookings
    SET BookingStatus='Cancelled'
    WHERE BookingId=@BookingId";

                SqlCommand bookingCmd =
                new SqlCommand(updateBooking, con);

                bookingCmd.Parameters.AddWithValue("@BookingId", bookingId);

                bookingCmd.ExecuteNonQuery();

                string seatColumn = "";

                if (travelClass == "2AC")
                    seatColumn = "Available2ACSeats";

                else if (travelClass == "3AC")
                    seatColumn = "Available3ACSeats";

                else
                    seatColumn = "AvailableSleeperSeats";

                string updateSeats =
                $"UPDATE Trains SET {seatColumn}={seatColumn}+@Count WHERE TrainNo=@TrainNo";

                SqlCommand seatCmd =
                new SqlCommand(updateSeats, con);

                seatCmd.Parameters.AddWithValue("@Count", passengerCount);
                seatCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                seatCmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine("Ticket Cancelled Successfully");
                Console.WriteLine("Refund Amount : " + refund);
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

    }
}
