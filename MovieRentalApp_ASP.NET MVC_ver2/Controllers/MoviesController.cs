using MovieRentalApp_ASP.NET_MVC_ver2.Models;
using MovieRentalApp_ASP.NET_MVC_ver2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MovieRentalApp_ASP.NET_MVC_ver2.Controllers
{
    public class MoviesController : Controller
    {

        /*
        // GET: Movies/Released/{year}/{month}
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("year : {0} month : {1}", year, month));
        }
        */



        private MyDbContext _context;

        public MoviesController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }


        // GET: Movies/
        public ActionResult Index(int? id)
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        
        //GET : Movies/Details/{id}
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c=>c.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
            
        }


        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres,
                Movie = new Movie()
            };
           

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
            

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;

                _context.Movies.Add(movie);
            }
            else
            {
                var movieIdDb = _context.Movies.Single(m => m.Id == movie.Id);
                /*
                TryUpdateModel(movieInDb);
                properties in movieInDb object will be updated based on the key-value pairs in request data. 
                This is an official Microsoft aproach suggested in ASP.NET tutorials on their page.
                I will not use this approach because of the following issues:
                1) it opens up security holes in the application: if we don't want the user to be able to update all properties in the Form but the User will be smart hacker may add additional key-value pairs in form data and with the method Hacker will update all properties.

                Microsoft proposed the solution which is using the 3rd argument with the specified properties to be updated ex : TryUpdateModel(movieInDb, "", new string[] {"Name", "Email"});
                 In this approach the problem is the magic strings. 

                So will will ue another way to updated properties...
                 */
                movieIdDb.Name = movie.Name;
                movieIdDb.NumberInStock = movie.NumberInStock;
                movieIdDb.ReleaseDate = movie.ReleaseDate;
                movieIdDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Movies");
        }

        public  ActionResult Edit (int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()

            };
                
            return View("MovieForm", viewModel);
        }
    }
}
