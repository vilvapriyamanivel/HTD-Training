using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniproject.Models
{
    
        public class Booking
        {
            public int BookingId { get; set; }

            public DateTime TravelDate { get; set; }

            public int UserId { get; set; }

            public int TrainNo { get; set; }

            public string TravelClass { get; set; }

            public int PassengerCount { get; set; }

            public decimal Amount { get; set; }

            public string BookingStatus { get; set; }

            public string BookingType { get; set; }
        }
    
}
