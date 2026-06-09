using Question2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Question2.Controllers
{



    public class OrdersController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();


        [HttpGet]
        [Route("api/orders/buchanan")]
        public IHttpActionResult GetOrdersByEmployee()
        {
            var orders = db.Orders
                           .Where(o => o.EmployeeID == 5)
                           .ToList();  

            return Ok(orders);
        }
    }
}
