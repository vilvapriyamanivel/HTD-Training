using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assessment3
{
    class Program2
    {
        static void Main()
        {
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine();

            Console.Write("Enter text to write: ");
            string text = Console.ReadLine();

            WriteTextToFile(fileName, text);
        }

        // Function to handle file operations
        static void WriteTextToFile(string fileName, string text)
        {
            if (File.Exists(fileName))
            {
                AppendToFile(fileName, text);
                Console.WriteLine("File exists. Text appended successfully.");
            }
            else
            {
                CreateAndWriteFile(fileName, text);
                Console.WriteLine("File not found. New file created and text written.");
            }
        }

        static void AppendToFile(string fileName, string text)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(text);
            }
        }

        static void CreateAndWriteFile(string fileName, string text)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(text);
            }
        }
    }
}
