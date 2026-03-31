using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Student1
    {
        public int RollNo;
        public string Name;
        public string classofstudent;
        public int Semester;
        public string Branch;
        int[] Marks = new int[5];
        public Student1(int rollno, string name, string classofstudent, int semester, string branch)
        {
            this.RollNo = rollno;
            this.Name = name;
            this.classofstudent = classofstudent;
            this.Semester = semester;
            this.Branch = branch;
            Console.WriteLine("Enter marks of 5 subjects:");
            GetMarks();
        }


        public void GetMarks()
        {
            Marks[0] = Convert.ToInt16(Console.ReadLine());
            Marks[1] = Convert.ToInt16(Console.ReadLine());
            Marks[2] = Convert.ToInt16(Console.ReadLine());
            Marks[3] = Convert.ToInt16(Console.ReadLine());
            Marks[4] = Convert.ToInt16(Console.ReadLine());
        }
        public void Result()
        {
            int total = 0;
            for (int i = 0; i < 5; i++)
            {
                total += Marks[i];
                if (Marks[i] < 35)
                {
                    Console.WriteLine("Sorry You Fail  But Don't Giveup");
                    return;
                }
            }
            int avg = total / 5;
            for (int i = 0; i < 5; i++)
            {
                if (Marks[i] > 35 && avg < 50)
                {
                    Console.WriteLine("Sorry You Failed But  Don't Give up");
                    return;
                }
            }
            Console.WriteLine(" Congratulations");
            Console.WriteLine(" You Passed!");

        }


    }
    public class Stumain
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter Roll No:");
            int RollNo= Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name:");
            string Name= Console.ReadLine();
            Console.Write("Enter Class:");
            string classofstudent= Console.ReadLine();
            Console.Write("Enter Semester:");
            int Semester = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Branch:");
            string Branch= Console.ReadLine();

             Student1 s1 = new Student1(RollNo, Name, classofstudent, Semester, Branch);
            s1.Result();
        }
    }
}



