using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Assessment7
{
    class Question1
    {

        public static SqlConnection conn = new SqlConnection(
            "server=ICS-LT-7BBQLB4\\SQLEXPRESS01; database=employeemanagement; integrated security=true;");

        public static SqlCommand cmd = null;
        public static SqlDataReader dataReader = null;

        static void Main(string[] args)
        {
            InsertEmployee();
            DisplayEmployees();

            Console.Read();
        }

        //  generate empno and take input
        public static void InsertEmployee()
        {
            try
            {
                conn.Open();

                int newempno = 0;

                //generate empno
                cmd = new SqlCommand("select isnull(max(empno),0) + 1 from employee_details", conn);
                newempno = (int)cmd.ExecuteScalar();

                Console.WriteLine("Generated Employee Number: " + newempno);

                // get user input
                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Salary: ");
                decimal sal = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter Type (f/p): ");
                string type = Console.ReadLine();

                //call stored procedure
                cmd = new SqlCommand("addemployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@empname", name);
                cmd.Parameters.AddWithValue("@empsal", sal);
                cmd.Parameters.AddWithValue("@emptype", type);

                int res = cmd.ExecuteNonQuery();

                Console.WriteLine("----- insert operation -----");
                Console.WriteLine(res + " row inserted successfully");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // display data
        public static void DisplayEmployees()
        {
            try
            {
                conn.Open();

                cmd = new SqlCommand("select * from employee_details", conn);
                dataReader = cmd.ExecuteReader();

                Console.WriteLine("----- employee details -----");

                while (dataReader.Read())
                {
                    Console.WriteLine(
                        dataReader["empno"] + " " +
                        dataReader["empname"] + " " +
                        dataReader["empsal"] + " " +
                        dataReader["emptype"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}