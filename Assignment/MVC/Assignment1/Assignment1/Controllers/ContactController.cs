using Assignment1.Models;
using Assignment1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        //public ActionResult Index()
        //{
        //    return View();
        //}
        

        private readonly IContactRepository _repo;

        public ContactController()
        {
            _repo = new ContactRepository(new ContactContext());
        }

        public async Task<ActionResult> Index()
        {
            var list = await _repo.GetAllAsync();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public async Task<ActionResult> Delete(long id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }

    
}