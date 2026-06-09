using Question2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Question2.Controllers
{
    public class CustomersController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        [HttpGet]
        [Route("api/customers/bycountry")]
        public IHttpActionResult GetCustomers(string country)
        {
            var customers = db.GetCustomersByCountry(country).ToList();

            return Ok(customers);
        }
    }
}
