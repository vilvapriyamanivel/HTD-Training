using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace client.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipCountry { get; set; }
    }
}