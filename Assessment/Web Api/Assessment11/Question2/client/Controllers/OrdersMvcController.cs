using client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http.Formatting;
using System.Web.Mvc;


namespace client.Controllers
{
    public class OrdersMvcController : Controller
    {

        public async Task<ActionResult> Index()
        {
            var orders = new List<Order>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:44375/"); 

                var response = await client.GetAsync("api/orders/buchanan");

                if (response.IsSuccessStatusCode)
                {
                    orders = await response.Content.ReadAsAsync<List<Order>>();
                }
            }

            return View(orders);
        }
    }
}