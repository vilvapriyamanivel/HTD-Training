using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGeneratorApp.Abstract;
using ReportGeneratorApp.Interface;
using ReportGeneratorApp.Factories;

namespace ReportGeneratorApp.Question
{
    class Question2main
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Report Type: Chart | Tabular | Summary");
            string userChoice = Console.ReadLine();

            ReportFactory factory = null;

            if (userChoice == "Chart")
            {
                factory = new ChartReportFactory();
            }
            else if (userChoice == "Tabular")
            {
                factory = new TabularReportFactory();
            }
            else if (userChoice == "Summary")
            {
                factory = new SummaryReportFactory();
            }
            else
            {
                Console.WriteLine("Invalid report type");
                return;
            }

            IReportGenerator report = factory.CreateReport();
            report.GenerateReport();
        }
    }
}