using System;

struct DateOfBirth
{
    public int day;
    public int month;
    public int year;
}

struct Employee
{
    public string name;
    public DateOfBirth dob;
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter The Number Of Employees: ");
        int n= int.Parse(Console.ReadLine());
        Employee[] emp = new Employee[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Name of the employee{0} : ", i + 1);
            emp[i].name = Console.ReadLine();

            Console.Write("Input day of the birth : ");
            emp[i].dob.day = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input month of the birth : ");
            emp[i].dob.month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input year for the birth : ");
            emp[i].dob.year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
        }

        Console.WriteLine("Employee Details");
        Console.WriteLine("-----------------------------");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Name : {0}", emp[i].name);
            Console.WriteLine("Date of Birth : {0}/{1}/{2}",
                emp[i].dob.day,
                emp[i].dob.month,
                emp[i].dob.year);
            Console.WriteLine();
        }
    }
}
