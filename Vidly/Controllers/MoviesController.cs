using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }

        // new action avaiable only for admin users
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var modelView = new MovieFormViewModel()
            {
                 //Movie = new Movie(),
                Geners = _context.Genres
            };
            return View("MovieForm",modelView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {

            //validation
            if (!ModelState.IsValid) {
                var viewModel = new MovieFormViewModel(movie)
                {
                    
                    Geners = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
           
            
            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);
            if (movie == null) {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movie)
            {
             
                Geners = _context.Genres.ToList()
            };
            return View("MovieForm",viewModel);
        }
        public ActionResult Detailes(int id) {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
         
                return View(movie);


        }
        

    }
}