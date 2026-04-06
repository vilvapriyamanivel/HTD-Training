using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;    
using System.Threading.Tasks;

namespace Assignment6
{
    

class CountLinesInFile
    {
        static void Main()
        {
            // Specify the file path
            string filePath = "sample.txt";

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read all lines and count them
                int lineCount = File.ReadAllLines(filePath).Length;

                Console.WriteLine("Number of lines in the file: " + lineCount);
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
    }
}
