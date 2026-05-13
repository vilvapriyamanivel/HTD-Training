using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Assessment7
{
    class Question2
    {
        public static SqlConnection conn = new SqlConnection(
            "server=ICS-LT-7BBQLB4\\SQLEXPRESS01; database=employeemanagement; integrated security=true;");

        public static SqlCommand cmd = null;
        public static SqlDataReader dataReader = null;

        static void Main(string[] args)
        {
            UpdateSalary();
            DisplayEmployees();

            Console.Read();
        }

        //update salary 
        public static void UpdateSalary()
        {
            try
            {
                conn.Open();

                Console.Write("Enter Employee ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                cmd = new SqlCommand("updatsalary", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@empid", id);

                
                decimal updatedSalary = (decimal)cmd.ExecuteScalar();

                Console.WriteLine("Updated Salary: " + updatedSalary);
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

        //display all employees
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
