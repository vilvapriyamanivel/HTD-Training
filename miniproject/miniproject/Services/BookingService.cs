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
                int trainNo = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Travel Date : ");
                DateTime travelDate = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("\n1. 2AC");
                Console.WriteLine("2. 3AC");
                Console.WriteLine("3. Sleeper");

                Console.Write("Choose Class : ");
                int classChoice = Convert.ToInt32(Console.ReadLine());

                string travelClass = "";
                string seatColumn = "";
                string chargeColumn = "";
                string prefix = "";

                if (classChoice == 1)
                {
                    travelClass = "2AC";
                    seatColumn = "Available2ACSeats";
                    chargeColumn = "Charge2AC";
                    prefix = "A";
                }
                else if (classChoice == 2)
                {
                    travelClass = "3AC";
                    seatColumn = "Available3ACSeats";
                    chargeColumn = "Charge3AC";
                    prefix = "B";
                }
                else
                {
                    travelClass = "Sleeper";
                    seatColumn = "AvailableSleeperSeats";
                    chargeColumn = "ChargeSleeper";
                    prefix = "S";
                }
                SqlConnection con = new SqlConnection(DbConfig.ConnectionString);
                con.Open();
                ShowStops(trainNo);

                Console.Write("Enter Boarding Stop Order : ");
                int boardingOrder = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Dropping Stop Order : ");
                int droppingOrder = Convert.ToInt32(Console.ReadLine());

                // validation
                if (boardingOrder >= droppingOrder)
                {
                    Console.WriteLine("Invalid selection");
                    return;
                }

               

                SqlCommand stopCmd = new SqlCommand(@"
SELECT StationName
FROM TrainStops
WHERE TrainNo=@TrainNo AND StopOrder=@Order", con);

                // Boarding point
                stopCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                stopCmd.Parameters.AddWithValue("@Order", boardingOrder);

                string boardingPoint = stopCmd.ExecuteScalar().ToString();

                // Dropping point
                stopCmd.Parameters.Clear();
                stopCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                stopCmd.Parameters.AddWithValue("@Order", droppingOrder);

                string droppingPoint = stopCmd.ExecuteScalar().ToString();


                Console.Write("Passenger Count(Max 3) : ");
                int passengerCount = Convert.ToInt32(Console.ReadLine());

                // SqlConnection con = new SqlConnection(DbConfig.ConnectionString);
                //con.Open();

                if (passengerCount > 3)
                {
                    Console.WriteLine("Maximum 3 Tickets Allowed");
                    return;
                }

                // GET TRAIN DETAILS
                string query = $"SELECT {seatColumn},{chargeColumn} FROM Trains WHERE TrainNo=@TrainNo";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TrainNo", trainNo);

                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.Read())
                {
                    Console.WriteLine("Invalid Train Number");
                    return;
                }

                int availableSeats = Convert.ToInt32(dr[seatColumn]);
                decimal charge = Convert.ToDecimal(dr[chargeColumn]);

                dr.Close();
                int confirmedCount = Math.Min(availableSeats, passengerCount);
                int waitingCount = passengerCount - confirmedCount;
                string bookingType =
confirmedCount > 0 && waitingCount > 0 ? "Partially Confirmed" :
confirmedCount > 0 ? "Confirmed" : "Waiting";
                //string bookingType = availableSeats >= passengerCount ? "Confirmed" : "Waiting";

                decimal amount = passengerCount * charge;

                // INSERT BOOKING
                SqlCommand bookingCmd = new SqlCommand(@"
            INSERT INTO Bookings
            (TravelDate, UserId, TrainNo, TravelClass, PassengerCount, Amount, BookingType, BoardingPoint, DroppingPoint)
            VALUES
            (@TravelDate, @UserId, @TrainNo, @TravelClass, @PassengerCount, @Amount, @BookingType, @BoardingPoint, @DroppingPoint)", con);

                bookingCmd.Parameters.AddWithValue("@TravelDate", travelDate);
                bookingCmd.Parameters.AddWithValue("@UserId", UserService.loggedInUserId);
                bookingCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                bookingCmd.Parameters.AddWithValue("@TravelClass", travelClass);
                bookingCmd.Parameters.AddWithValue("@BoardingPoint", boardingPoint);
                bookingCmd.Parameters.AddWithValue("@DroppingPoint", droppingPoint);
                bookingCmd.Parameters.AddWithValue("@PassengerCount", passengerCount);
                bookingCmd.Parameters.AddWithValue("@Amount", amount);
                bookingCmd.Parameters.AddWithValue("@BookingType", bookingType);

                bookingCmd.ExecuteNonQuery();

                int bookingId = Convert.ToInt32(new SqlCommand("SELECT MAX(BookingId) FROM Bookings", con).ExecuteScalar());

                // GET LAST SEAT NUMBER FROM DB
                SqlCommand seatCmd = new SqlCommand(@"
            SELECT TOP 1 SeatNumber
            FROM Passengers P
            JOIN Bookings B ON P.BookingId = B.BookingId
            WHERE B.TrainNo=@TrainNo AND B.TravelClass=@Class
            ORDER BY P.PassengerId DESC", con);

                seatCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                seatCmd.Parameters.AddWithValue("@Class", travelClass);

                object result = seatCmd.ExecuteScalar();

                int seatCounter = 1;

                if (result != null)
                {
                    string lastSeat = result.ToString();
                    string numberPart = new string(lastSeat.Where(char.IsDigit).ToArray());

                    if (!string.IsNullOrEmpty(numberPart))
                        seatCounter = Convert.ToInt32(numberPart) + 1;
                }

                // PASSENGERS LOOP
                for (int i = 1; i <= passengerCount; i++)
                {
                    Console.WriteLine("\nPassenger " + i);

                    Console.Write("Name : ");
                    string name = Console.ReadLine();

                    Console.Write("Age : ");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Select Gender (1.Male 2.Female 3.Other): ");
                    int g = Convert.ToInt32(Console.ReadLine());
                    string gender = g == 1 ? "Male" : g == 2 ? "Female" : "Other";

                    Console.WriteLine("Select ID Proof (1.Aadhar 2.PAN 3.Passport 4.VoterID): ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    string idProofType = id == 1 ? "Aadhar" :
                                         id == 2 ? "PAN" :
                                         id == 3 ? "Passport" : "VoterID";

                    Console.Write("ID Number : ");
                    string idProofNumber = Console.ReadLine();

                    Console.Write("Phone : ");
                    string phone = Console.ReadLine();

                    string seatNo = "Waiting";

                    //if (bookingType == "Confirmed")
                    //{
                    //    seatNo = prefix + seatCounter;
                    //    seatCounter++;
                    //}
                    if (i <= confirmedCount)
                    {
                        seatNo = prefix + seatCounter;
                        seatCounter++;
                    }
                    else
                    {
                        seatNo = "Waiting";
                    }

                    Console.WriteLine("Seat Number : " + seatNo);

                    SqlCommand passCmd = new SqlCommand(@"
                INSERT INTO Passengers
                (BookingId, PassengerName, Age, Gender, IdProofType, IdProofNumber, PhoneNumber, SeatNumber,Status)
                VALUES
                (@BookingId, @PassengerName, @Age, @Gender, @IdProofType, @IdProofNumber, @PhoneNumber, @SeatNumber,'Active')", con);

                    passCmd.Parameters.AddWithValue("@BookingId", bookingId);
                    passCmd.Parameters.AddWithValue("@PassengerName", name);
                    passCmd.Parameters.AddWithValue("@Age", age);
                    passCmd.Parameters.AddWithValue("@Gender", gender);
                    passCmd.Parameters.AddWithValue("@IdProofType", idProofType);
                    passCmd.Parameters.AddWithValue("@IdProofNumber", idProofNumber);
                    passCmd.Parameters.AddWithValue("@PhoneNumber", phone);
                    passCmd.Parameters.AddWithValue("@SeatNumber", seatNo);

                    passCmd.ExecuteNonQuery();
                }

                if (confirmedCount > 0)
                {
                    SqlCommand updateCmd = new SqlCommand(
                        $"UPDATE Trains SET {seatColumn}={seatColumn}-@ConfirmedCount WHERE TrainNo=@TrainNo", con);

                    updateCmd.Parameters.AddWithValue("@ConfirmedCount", confirmedCount);
                    updateCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                    updateCmd.ExecuteNonQuery();
                }
                Console.WriteLine("\nBooking Successful");
                Console.WriteLine("Booking ID : " + bookingId);
                Console.WriteLine("Booking Type : " + bookingType);
                Console.WriteLine("Total Amount : " + amount);
                Console.WriteLine("Boarding Point : " + boardingPoint);
                Console.WriteLine("Dropping Point : " + droppingPoint);
                Console.WriteLine("\n===== TICKET DETAILS =====");

                SqlCommand viewCmd = new SqlCommand(
                @"SELECT PassengerName, Age, Gender, SeatNumber, IdProofType
  FROM Passengers
  WHERE BookingId=@BookingId", con);

                viewCmd.Parameters.AddWithValue("@BookingId", bookingId);

                SqlDataReader pr = viewCmd.ExecuteReader();

                while (pr.Read())
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Name : " + pr["PassengerName"]);
                    Console.WriteLine("Age : " + pr["Age"]);
                    Console.WriteLine("Gender : " + pr["Gender"]);
                    Console.WriteLine("Seat No : " + pr["SeatNumber"]);
                    Console.WriteLine("ID Type : " + pr["IdProofType"]);
                    //Console.WriteLine("Passenger ID : " + pr["PassengerId"]);
                    //Console.WriteLine("Name : " + pr["PassengerName"]);
                    //Console.WriteLine("Seat No : " + pr["SeatNumber"]);
                    //Console.WriteLine("Status : " + pr["PassengerStatus"]);
                }

                pr.Close();
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

                int bookingId = Convert.ToInt32(dr["BookingId"]);

                Console.WriteLine("Booking ID : " + bookingId);
                Console.WriteLine("Train No : " + dr["TrainNo"]);
                Console.WriteLine("Travel Class : " + dr["TravelClass"]);
                Console.WriteLine("Boarding Point : " + dr["BoardingPoint"]);
                Console.WriteLine("Dropping Point : " + dr["DroppingPoint"]);
                Console.WriteLine("Travel Date : " +
                Convert.ToDateTime(dr["TravelDate"]).ToShortDateString());
                Console.WriteLine("Passengers : " + dr["PassengerCount"]);
                Console.WriteLine("Amount : " + dr["Amount"]);
                Console.WriteLine("Booking Status : " + dr["BookingStatus"]);
                Console.WriteLine("Booking Type : " + dr["BookingType"]);

                Console.WriteLine("\n--- PASSENGERS ---");

                // CLOSE FIRST READER BEFORE NEW QUERY
                SqlConnection con2 = new SqlConnection(DbConfig.ConnectionString);
                con2.Open();

                SqlCommand passCmd = new SqlCommand(
@"SELECT PassengerId, PassengerName, Age, Gender, SeatNumber, Status, IdProofType, IdProofNumber
  FROM Passengers
  WHERE BookingId=@BookingId", con2);

                passCmd.Parameters.AddWithValue("@BookingId", bookingId);

                SqlDataReader pr = passCmd.ExecuteReader();

                while (pr.Read())
                {
                    Console.WriteLine("Passenger ID : " + pr["PassengerId"]);
                    Console.WriteLine("Name : " + pr["PassengerName"]);
                    Console.WriteLine("Age : " + pr["Age"]);
                    Console.WriteLine("Gender : " + pr["Gender"]);
                    Console.WriteLine("Seat No : " + pr["SeatNumber"]);
                    //Console.WriteLine("Status : " + pr["Status"]);
                    string seatNo = pr["SeatNumber"].ToString();

                    Console.WriteLine("Seat No : " + seatNo);

                    if (pr["Status"].ToString() == "Cancelled")
                    {
                        Console.WriteLine("Status : Cancelled");
                    }
                    else if (seatNo == "Waiting")
                    {
                        Console.WriteLine("Status : Waiting");
                    }
                    else
                    {
                        Console.WriteLine("Status : Confirmed");
                    }
                    Console.WriteLine("ID Type : " + pr["IdProofType"]);
                    Console.WriteLine("ID Number : " + pr["IdProofNumber"]);
                    Console.WriteLine("----------------------");
                }

                pr.Close();
                con2.Close();

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
                string prefix = "";

                if (travelClass == "2AC")
                    prefix = "A";
                else if (travelClass == "3AC")
                    prefix = "B";
                else
                    prefix = "S";

                for (int i = 0; i < passengerCount; i++)
                {
                    PromoteWaitingPassenger(
                        trainNo,
                        travelClass,
                        prefix);
                }

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
        public static void CancelPassenger()
        {
            SqlConnection con = new SqlConnection(DbConfig.ConnectionString);
            con.Open();

            Console.Write("Enter Booking ID : ");
            int bookingId = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand(@"
        SELECT PassengerId, PassengerName, SeatNumber
        FROM Passengers
        WHERE BookingId=@BookingId AND Status='Active'", con);

            cmd.Parameters.AddWithValue("@BookingId", bookingId);

            SqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine("\n--- PASSENGERS ---");
            Console.WriteLine("Passenger ID - Name - Seat No");
            while (dr.Read())
            {
                Console.WriteLine(
                    dr["PassengerId"] + " - " +
                    dr["PassengerName"] + " - " +
                    dr["SeatNumber"]);
            }

            dr.Close();

            Console.Write("\nEnter Passenger ID to cancel : ");
            int passengerId = Convert.ToInt32(Console.ReadLine());

            // get seat
            SqlCommand getSeat = new SqlCommand(@"
        SELECT SeatNumber FROM Passengers WHERE PassengerId=@Id", con);

            getSeat.Parameters.AddWithValue("@Id", passengerId);

            string seat = getSeat.ExecuteScalar().ToString();

            bool wasWaiting = seat == "Waiting";

            // update passenger
            SqlCommand update = new SqlCommand(@"
        UPDATE Passengers
        SET Status='Cancelled'
        WHERE PassengerId=@Id", con);

            update.Parameters.AddWithValue("@Id", passengerId);
            update.ExecuteNonQuery();

            Console.WriteLine("\nPassenger Cancellation Successful");
            //Console.WriteLine("Seat Released : " + seat);

            // get booking + class + train for that passenger
            SqlCommand infoCmd = new SqlCommand(@"
SELECT B.TrainNo, B.TravelClass
FROM Passengers P
JOIN Bookings B ON P.BookingId = B.BookingId
WHERE P.PassengerId=@Id", con);

            infoCmd.Parameters.AddWithValue("@Id", passengerId);

            SqlDataReader infoDr = infoCmd.ExecuteReader();

            int trainNo = 0;
            string travelClass = "";

            if (infoDr.Read())
            {
                trainNo = Convert.ToInt32(infoDr["TrainNo"]);
                travelClass = infoDr["TravelClass"].ToString();
            }

            infoDr.Close();

            // decide column
            string seatColumn = "";

            if (travelClass == "2AC")
                seatColumn = "Available2ACSeats";
            else if (travelClass == "3AC")
                seatColumn = "Available3ACSeats";
            else
                seatColumn = "AvailableSleeperSeats";

            // update seat count
            if (!wasWaiting)
            {
                SqlCommand seatUpdate = new SqlCommand(
                $"UPDATE Trains SET {seatColumn} = {seatColumn} + 1 WHERE TrainNo=@TrainNo", con);

                seatUpdate.Parameters.AddWithValue("@TrainNo", trainNo);
                seatUpdate.ExecuteNonQuery();
            }
            string prefix = "";

            if (travelClass == "2AC")
                prefix = "A";
            else if (travelClass == "3AC")
                prefix = "B";
            else
                prefix = "S";

            if (!wasWaiting)
            {
                PromoteWaitingPassenger(
                    trainNo,
                    travelClass,
                    prefix);
            }

            con.Close();
        }
        public static void ShowStops(int trainNo)
        {
            SqlConnection con = new SqlConnection(DbConfig.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(@"
        SELECT StationName, StopOrder
        FROM TrainStops
        WHERE TrainNo=@TrainNo
        ORDER BY StopOrder", con);

            cmd.Parameters.AddWithValue("@TrainNo", trainNo);

            SqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine("\n--- TRAIN STOPS ---");

            while (dr.Read())
            {
                Console.WriteLine($"{dr["StopOrder"]}. {dr["StationName"]}");
            }

            dr.Close();
            con.Close();
        }
        public static void PromoteWaitingPassenger(
    int trainNo,
    string travelClass,
    string prefix)
        {
            SqlConnection con =
            new SqlConnection(DbConfig.ConnectionString);

            con.Open();

            // First waiting passenger
            SqlCommand cmd = new SqlCommand(@"
    SELECT TOP 1
    P.PassengerId
    FROM Passengers P
    JOIN Bookings B
    ON P.BookingId = B.BookingId
    WHERE B.TrainNo=@TrainNo
    AND B.TravelClass=@Class
    AND P.SeatNumber='Waiting'
    AND P.Status='Active'
    ORDER BY P.PassengerId", con);

            cmd.Parameters.AddWithValue("@TrainNo", trainNo);
            cmd.Parameters.AddWithValue("@Class", travelClass);

            object result = cmd.ExecuteScalar();

            if (result == null)
            {
                con.Close();
                return;
            }

            int passengerId =
            Convert.ToInt32(result);

            // Get next seat number
            SqlCommand seatCmd =
            new SqlCommand(@"
    SELECT COUNT(*)
    FROM Passengers
    WHERE SeatNumber<>'Waiting'
    AND Status='Active'", con);

            int seatNo =
            Convert.ToInt32(seatCmd.ExecuteScalar()) + 1;

            string newSeat =
            prefix + seatNo;

            SqlCommand update =
            new SqlCommand(@"
    UPDATE Passengers
    SET SeatNumber=@SeatNo
    WHERE PassengerId=@Id", con);

            update.Parameters.AddWithValue("@SeatNo", newSeat);
            update.Parameters.AddWithValue("@Id", passengerId);

            update.ExecuteNonQuery();
            string seatColumn = "";

if (travelClass == "2AC")
    seatColumn = "Available2ACSeats";
else if (travelClass == "3AC")
    seatColumn = "Available3ACSeats";
else
    seatColumn = "AvailableSleeperSeats";

SqlCommand seatReduce = new SqlCommand(
$@"UPDATE Trains
SET {seatColumn} = {seatColumn} - 1
WHERE TrainNo=@TrainNo", con);

seatReduce.Parameters.AddWithValue("@TrainNo", trainNo);

seatReduce.ExecuteNonQuery();

            //Console.WriteLine(
            //"Waiting Passenger Confirmed : "
            //+ newSeat);

            con.Close();
        }

    }
}