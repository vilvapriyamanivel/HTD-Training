using System;


namespace Assignment2
{
    public class Program
    {
        static void Main(string[] args)
        {
            arravgminmax();
            arrmarks();
            arrcopy();
            Strassignment strassignment = new Strassignment();
            strassignment.wordlength();
        }
        public static void arravgminmax()
        {
            Console.Write("Enter array size:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine("Enter Array elements :");
            for (int j = 0; j < n; j++)
            {
                arr[j] = Convert.ToInt32(Console.ReadLine());
            }
            int sum = 0;
            int max = int.MinValue;
            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                sum += arr[i];
            }
            int avg = sum / n;
            Console.WriteLine($"The Minimum of the given Array is {min}");
            Console.WriteLine($"The Maximum of the given Array is {max}");
            Console.WriteLine($"The Avrage of the given Array is {avg}");
        }
        public static void arrmarks()
        {
            Console.Write("Enter number of subjects:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] marks = new int[n];
            Console.WriteLine("Enter subject Marks :");
            for (int j = 0; j < n; j++)
            {
                marks[j] = Convert.ToInt32(Console.ReadLine());
            }
            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (marks[i] > max)
                {
                    max = marks[i];
                }
                if (marks[i] < min)
                {
                    min = marks[i];
                }
                sum += marks[i];
            }
            Console.WriteLine($"The Total marks is: {sum}");
            Console.WriteLine($"The Averge marks is: {sum / n}");
            Console.WriteLine($"The Minumum marks is: {min}");
            Console.WriteLine($"The Maximum marks is: {max}");
            for (int i = 0; i < n - 1; i++)
            {

                for (int j = i + 1; j < n; j++)
                {
                    if (marks[i] > marks[j])
                    {
                        int temp = marks[i];
                        marks[i] = marks[j];
                        marks[j] = temp;
                    }
                }
            }
            Console.WriteLine($"The marks in Ascending order is:");
            for (int k = 0; k < n; k++)
            {
                Console.WriteLine(marks[k]);
            }
            Console.WriteLine($"The marks in Descending order is:");
            for (int k = n - 1; k >= 0; k--)
            {
                Console.WriteLine(marks[k]);
            }

        }
        public static void arrcopy()
        {
            Console.Write("Enter array size:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr1 = new int[n];
            Console.WriteLine("Enter Array elements :");
            for (int j = 0; j < n; j++)
            {
                arr1[j] = Convert.ToInt32(Console.ReadLine());
            }
            int[] arr2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr2[i] = arr1[i];
            }
            Console.WriteLine($"The elements of the first array is:");
            for (int k = 0; k < n; k++)
            {
                Console.WriteLine(arr1[k]);
            }
            Console.WriteLine($"The elements of the second array is:");
            for (int k = 0; k < n; k++)
            {
                Console.WriteLine(arr2[k]);
            }
        }

    }
}

