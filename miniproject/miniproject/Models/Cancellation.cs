using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniproject.Models
{
    class Cancellation
        {
            public int CancellationId { get; set; }

            public int BookingId { get; set; }

            public decimal RefundAmount { get; set; }
        }
}
