using DBFirstQuestion1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DBFirstQuestion1.Controllers
{
    public class CodeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }
       

            //Customers from Germany
            public ActionResult GermanCustomers()
            {
                var customers = db.Customers
                                  .Where(c => c.Country == "Germany")
                                  .ToList();

                return View(customers);
            }

            // Customer for OrderID = 10248
            public ActionResult CustomerByOrder()
            {
                var customer = db.Orders
                                 .Where(o => o.OrderID == 10248)
                                 .Select(o => o.Customer)
                                 .FirstOrDefault();

                return View(customer);
            }
        }

    
}



   