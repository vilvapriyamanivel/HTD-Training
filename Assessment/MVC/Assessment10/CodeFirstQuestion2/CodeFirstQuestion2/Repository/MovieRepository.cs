using CodeFirstQuestion2.Models;
using CodeFirstQuestion2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstQuestion2.Repository
{
    public class MovieRepository: IMovieRepository
    {
    
        private MovieContext db = new MovieContext();

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public void Insert(Movie movie)
        {
            db.Movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
        }

        public IEnumerable<Movie> GetByYear(int year)
        {
            return db.Movies
                     .Where(m => m.DateOfRelease.Year == year)
                     .ToList();
        }

        public IEnumerable<Movie> GetByDirector(string name)
        {
            return db.Movies
                     .Where(m => m.DirectorName == name)
                     .ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
