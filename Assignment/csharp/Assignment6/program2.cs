using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Assignment6
{
    
class FileWriteReadExample
    {
        static void Main()
        {
            // File path (created in the application's directory)
            string filePath = "sample.txt";

            // Array of strings
            string[] linesToWrite =
            {
            "Hello, World!",
            "Welcome to C# file handling.",
            "This is a sample program.",
            "Reading and writing files is easy!"
        };

            // Write array of strings to file
            File.WriteAllLines(filePath, linesToWrite);
            Console.WriteLine("Data written to the file successfully.\n");

            // Read from the file
            string[] linesRead = File.ReadAllLines(filePath);

            Console.WriteLine("Contents of the file:");
            foreach (string line in linesRead)
            {
                Console.WriteLine(line);
            }
        }
    }

    }

