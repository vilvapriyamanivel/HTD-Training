using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReportGeneratorApp.Interface;

namespace ReportGeneratorApp.Abstract
{
    public abstract class ReportFactory
    {
        public abstract IReportGenerator CreateReport();
    }
}
