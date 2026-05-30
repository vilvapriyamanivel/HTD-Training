using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miniproject.Database;

namespace miniproject.Services
{
    public class TrainService
    {
        //add train
        public static void AddTrain()
        {
            try
            {
                Console.Clear();

                Console.Write("Enter Train No : ");
                int trainNo =
                Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Train Name : ");
                string trainName =
                Console.ReadLine();

                Console.Write("From Station : ");
                string fromStation =
                Console.ReadLine();

                Console.Write("To Station : ");
                string toStation =
                Console.ReadLine();

                Console.Write("Departure Time : ");
                TimeSpan departureTime =
                TimeSpan.Parse(Console.ReadLine());

                Console.Write("Arrival Time : ");
                TimeSpan arrivalTime =
                TimeSpan.Parse(Console.ReadLine());

                Console.Write("Journey Duration : ");
                string duration =
                Console.ReadLine();

                Console.WriteLine("\n2AC DETAILS");

                Console.Write("Total 2AC Seats : ");
                int total2AC =
                Convert.ToInt32(Console.ReadLine());

                Console.Write("Available 2AC Seats : ");
                int available2AC =
                Convert.ToInt32(Console.ReadLine());

                Console.Write("2AC Charge : ");
                decimal charge2AC =
                Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("\n3AC DETAILS");

                Console.Write("Total 3AC Seats : ");
                int total3AC =
                Convert.ToInt32(Console.ReadLine());

                Console.Write("Available 3AC Seats : ");
                int available3AC =
                Convert.ToInt32(Console.ReadLine());

                Console.Write("3AC Charge : ");
                decimal charge3AC =
                Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("\nSLEEPER DETAILS");

                Console.Write("Total Sleeper Seats : ");
                int totalSleeper =
                Convert.ToInt32(Console.ReadLine());

                Console.Write("Available Sleeper Seats : ");
                int availableSleeper =
                Convert.ToInt32(Console.ReadLine());

                Console.Write("Sleeper Charge : ");
                decimal chargeSleeper =
                Convert.ToDecimal(Console.ReadLine());

                SqlConnection con =
                new SqlConnection(DbConfig.ConnectionString);

                string query =
                @"INSERT INTO Trains
            (
                TrainNo,
                TrainName,
                FromStation,
                ToStation,
                DepartureTime,
                ArrivalTime,
                JourneyDuration,
                Total2ACSeats,
                Available2ACSeats,
                Charge2AC,
                Total3ACSeats,
                Available3ACSeats,
                Charge3AC,
                TotalSleeperSeats,
                AvailableSleeperSeats,
                ChargeSleeper,
                IsDeleted
            )
            VALUES
            (
                @TrainNo,
                @TrainName,
                @FromStation,
                @ToStation,
                @DepartureTime,
                @ArrivalTime,
                @JourneyDuration,
                @Total2ACSeats,
                @Available2ACSeats,
                @Charge2AC,
                @Total3ACSeats,
                @Available3ACSeats,
                @Charge3AC,
                @TotalSleeperSeats,
                @AvailableSleeperSeats,
                @ChargeSleeper,
                0
            )";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@FromStation", fromStation);
                cmd.Parameters.AddWithValue("@ToStation", toStation);
                cmd.Parameters.AddWithValue("@DepartureTime", departureTime);
                cmd.Parameters.AddWithValue("@ArrivalTime", arrivalTime);
                cmd.Parameters.AddWithValue("@JourneyDuration", duration);
                cmd.Parameters.AddWithValue("@Total2ACSeats", total2AC);
                cmd.Parameters.AddWithValue("@Available2ACSeats", available2AC);
                cmd.Parameters.AddWithValue("@Charge2AC", charge2AC);
                cmd.Parameters.AddWithValue("@Total3ACSeats", total3AC);
                cmd.Parameters.AddWithValue("@Available3ACSeats", available3AC);
                cmd.Parameters.AddWithValue("@Charge3AC", charge3AC);
                cmd.Parameters.AddWithValue("@TotalSleeperSeats", totalSleeper);
                cmd.Parameters.AddWithValue("@AvailableSleeperSeats", availableSleeper);
                cmd.Parameters.AddWithValue("@ChargeSleeper", chargeSleeper);

                con.Open();

                cmd.ExecuteNonQuery();

                Console.Write("How Many Stops : ");

                int stopCount =
                Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= stopCount; i++)
                {
                    Console.WriteLine("\nStop " + i);

                    Console.Write("Station Name : ");
                    string station =
                    Console.ReadLine();

                    Console.Write("Arrival Time : ");
                    TimeSpan arr =
                    TimeSpan.Parse(Console.ReadLine());

                    Console.Write("Departure Time : ");
                    TimeSpan dep =
                    TimeSpan.Parse(Console.ReadLine());

                    string stopQuery =
                    @"INSERT INTO TrainStops
                (
                    TrainNo,
                    StationName,
                    ArrivalTime,
                    DepartureTime,
                    StopOrder
                )
                VALUES
                (
                    @TrainNo,
                    @StationName,
                    @ArrivalTime,
                    @DepartureTime,
                    @StopOrder
                )";

                    SqlCommand stopCmd =
                    new SqlCommand(stopQuery, con);

                    stopCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    stopCmd.Parameters.AddWithValue("@StationName", station);
                    stopCmd.Parameters.AddWithValue("@ArrivalTime", arr);
                    stopCmd.Parameters.AddWithValue("@DepartureTime", dep);
                    stopCmd.Parameters.AddWithValue("@StopOrder", i);

                    stopCmd.ExecuteNonQuery();
                }

                con.Close();

                Console.WriteLine("Train Added Successfully");
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

        //view train
        public static void ViewTrains()
        {
            SqlConnection con =
            new SqlConnection(DbConfig.ConnectionString);

            string query =
            "SELECT * FROM Trains WHERE IsDeleted=0";

            SqlCommand cmd =
            new SqlCommand(query, con);

            con.Open();

            SqlDataReader dr =
            cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("====================================");

                Console.WriteLine(
                "Train No : " + dr["TrainNo"]);

                Console.WriteLine(
                "Train Name : " + dr["TrainName"]);

                Console.WriteLine(
                "Route : " +
                dr["FromStation"] +
                " -> " +
                dr["ToStation"]);

                Console.WriteLine(
                "Departure Time : " +
                dr["DepartureTime"]);

                Console.WriteLine(
                "Arrival Time : " +
                dr["ArrivalTime"]);

                Console.WriteLine(
                "Journey Duration : " +
                dr["JourneyDuration"]);

                Console.WriteLine("\n2AC");

                Console.WriteLine(
                "Available Seats : " +
                dr["Available2ACSeats"]);

                Console.WriteLine(
                "Charge : " +
                dr["Charge2AC"]);

                Console.WriteLine("\n3AC");

                Console.WriteLine(
                "Available Seats : " +
                dr["Available3ACSeats"]);

                Console.WriteLine(
                "Charge : " +
                dr["Charge3AC"]);

                Console.WriteLine("\nSleeper");

                Console.WriteLine(
                "Available Seats : " +
                dr["AvailableSleeperSeats"]);

                Console.WriteLine(
                "Charge : " +
                dr["ChargeSleeper"]);

                Console.WriteLine("====================================");
            }

            con.Close();
        }
        //search train
        public static void SearchTrains()
        {
            try
            {
                Console.Clear();

                Console.Write("From Station : ");
                string from = Console.ReadLine();

                Console.Write("To Station : ");
                string to = Console.ReadLine();

                SqlConnection con =
                new SqlConnection(DbConfig.ConnectionString);

                string query =
                @"SELECT *
        FROM Trains
        WHERE FromStation=@From
        AND ToStation=@To
        AND IsDeleted=0";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@From", from);
                cmd.Parameters.AddWithValue("@To", to);

                con.Open();

                SqlDataReader dr =
                cmd.ExecuteReader();

                List<int> trainNos =
                new List<int>();

                bool found = false;

                while (dr.Read())
                {
                    found = true;

                    Console.WriteLine("================================");

                    Console.WriteLine(
                    "Train No : " +
                    dr["TrainNo"]);

                    Console.WriteLine(
                    "Train Name : " +
                    dr["TrainName"]);

                    Console.WriteLine(
                    "Route : " +
                    dr["FromStation"] +
                    " -> " +
                    dr["ToStation"]);

                    Console.WriteLine(
                    "Departure Time : " +
                    dr["DepartureTime"]);

                    Console.WriteLine(
                    "Arrival Time : " +
                    dr["ArrivalTime"]);

                    Console.WriteLine(
                    "Journey Duration : " +
                    dr["JourneyDuration"]);

                    Console.WriteLine("================================");

                    trainNos.Add(
                    Convert.ToInt32(dr["TrainNo"]));
                }

                if (!found)
                {
                    Console.WriteLine("\nNo Train Available");
                }

                dr.Close();
                con.Close();

                foreach (int tno in trainNos)
                {
                    ViewStops(tno);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }
        //view stop
        public static void ViewStops(int trainNo)
        {
            SqlConnection con =
            new SqlConnection(DbConfig.ConnectionString);

            string query =
            @"SELECT *
    FROM TrainStops
    WHERE TrainNo=@TrainNo
    ORDER BY StopOrder";

            SqlCommand cmd =
            new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@TrainNo", trainNo);

            con.Open();

            SqlDataReader dr =
            cmd.ExecuteReader();

            Console.WriteLine("\n===== STOPPING POINTS =====");

            while (dr.Read())
            {
                Console.WriteLine(
                dr["StopOrder"] + ". " +
                dr["StationName"]);

                Console.WriteLine(
                "Arrival : " +
                dr["ArrivalTime"]);

                Console.WriteLine(
                "Departure : " +
                dr["DepartureTime"]);

                Console.WriteLine("---------------------------");
            }

            con.Close();
        }
        //stops
        public static List<string> GetStops(int trainNo)
        {
            List<string> stops = new List<string>();

            SqlConnection con =
            new SqlConnection(DbConfig.ConnectionString);

            string query =
            @"SELECT StationName
      FROM TrainStops
      WHERE TrainNo=@TrainNo
      ORDER BY StopOrder";

            SqlCommand cmd =
            new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@TrainNo", trainNo);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                stops.Add(dr["StationName"].ToString());
            }

            con.Close();

            return stops;
        }
        //delete train
        public  static void DeleteTrain()
        {
            try
            {
                Console.Write("Enter Train No : ");

                int trainNo =
                Convert.ToInt32(Console.ReadLine());

                SqlConnection con =
                new SqlConnection(DbConfig.ConnectionString);

                con.Open();

                string checkQuery =
                @"SELECT COUNT(*)
    FROM Bookings
    WHERE TrainNo=@TrainNo
    AND BookingStatus='Active'";

                SqlCommand checkCmd =
                new SqlCommand(checkQuery, con);

                checkCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                int count =
                Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    Console.WriteLine(
                    "Cannot Delete Train. Active Bookings Exist");

                    con.Close();
                    return;
                }
                string trainCheck =
    "SELECT COUNT(*) FROM Trains WHERE TrainNo=@TrainNo AND IsDeleted=0";

                SqlCommand trainCmd =
                new SqlCommand(trainCheck, con);

                trainCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                int trainExists =
                Convert.ToInt32(trainCmd.ExecuteScalar());

                if (trainExists == 0)
                {
                    Console.WriteLine("Train Not Found");
                    con.Close();
                    return;
                }

                string deleteQuery =
                @"UPDATE Trains
    SET IsDeleted=1
    WHERE TrainNo=@TrainNo";

                SqlCommand deleteCmd =
                new SqlCommand(deleteQuery, con);

                deleteCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                deleteCmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine("Train Deleted Successfully");
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
