using MovieRentalApp_ASP.NET_MVC_ver2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentalApp_ASP.NET_MVC_ver2.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Shrek!" };

            return View(movie);

        }


        // GET: Movies/Released/{year}/{month}
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("year : {0} month : {1}", year, month));
        }


        public ActionResult Index (int? id, string name)
        {
            if (!id.HasValue)
            {
                id = 11;
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Yaro";
            }
            return Content(string.Format("the id = {0} and name = {1}", id, name));

            
        }

    }
}