using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGeneratorApp.Abstract;
using ReportGeneratorApp.Interface;
using ReportGeneratorApp.Concrete;

namespace ReportGeneratorApp.Factories
{
    public class ChartReportFactory : ReportFactory
    {
        public override IReportGenerator CreateReport()
        {
            return new ChartReportGenerator();
        }
    }
}
