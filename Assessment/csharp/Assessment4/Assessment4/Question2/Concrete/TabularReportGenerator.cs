using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGeneratorApp.Interface;
namespace ReportGeneratorApp.Concrete
{
    public class TabularReportGenerator : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating tabular report...");
        }
    }
}
