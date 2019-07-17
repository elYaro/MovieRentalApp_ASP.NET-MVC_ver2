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
    }
}