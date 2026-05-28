using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniproject.Models
{
   
        class Train
        {
            public int TrainNo { get; set; }

            public string TrainName { get; set; }

            public string FromStation { get; set; }

            public string ToStation { get; set; }

            public string DepartureTime { get; set; }

            public string ArrivalTime { get; set; }

            public string JourneyDuration { get; set; }

            public int Available2ACSeats { get; set; }

            public decimal Charge2AC { get; set; }

            public int Available3ACSeats { get; set; }

            public decimal Charge3AC { get; set; }

            public int AvailableSleeperSeats { get; set; }

            public decimal ChargeSleeper { get; set; }
        }
    
}
