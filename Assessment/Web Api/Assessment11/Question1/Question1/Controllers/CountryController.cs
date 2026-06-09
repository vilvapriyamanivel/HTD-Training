using Question1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Question1.Controllers
{
  

    public class CountryController : ApiController
    {
        
        static List<Country> countries = new List<Country>()
        {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "USA", Capital = "Washington DC" }
        };

      
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(countries);
        }

        
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            return Ok(country);
        }

       
        [HttpPost]
        public IHttpActionResult AddCountry(Country country)
        {
            if (country == null)
                return BadRequest("Invalid data");

            country.ID = countries.Max(c => c.ID) + 1;
            countries.Add(country);

            return Ok(country);
        }

        
        [HttpPut]
        public IHttpActionResult UpdateCountry(int id, Country updatedCountry)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            country.CountryName = updatedCountry.CountryName;
            country.Capital = updatedCountry.Capital;

            return Ok(country);
        }

        
        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            countries.Remove(country);
            return Ok("Deleted Successfully");
        }
    }
}