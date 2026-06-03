using CodeFirstQuestion2.Models;
using CodeFirstQuestion2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstQuestion2.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        private IMovieRepository repo = new MovieRepository();
        
       // CREATE
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            repo.Insert(movie);
            repo.Save();
            return RedirectToAction("Index");
        }

        // READ ALL
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // EDIT
        public ActionResult Edit(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            repo.Save();
            return RedirectToAction("Index");
        }

        // DELETE
        public ActionResult Delete(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            repo.Save();
            return RedirectToAction("Index");
        }

        // 🔹 Movies by Year
        public ActionResult MoviesByYear(int year)
        {
            var movies = repo.GetByYear(year);
            return View(movies);
        }

        // 🔹 Movies by Director
        public ActionResult MoviesByDirector(string name)
        {
            var movies = repo.GetByDirector(name);
            return View(movies);
        }
    }
}