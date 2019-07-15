﻿using MovieRentalApp_ASP.NET_MVC_ver2.Models;
using MovieRentalApp_ASP.NET_MVC_ver2.ViewModels;
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
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Bolek" },
                new Customer { Id = 2, Name = "Lolek" },
                new Customer { Id = 3, Name = "Tola"}
            };

            var ViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(ViewModel);
        }


        // GET: Movies/Released/{year}/{month}
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("year : {0} month : {1}", year, month));
        }

        // GET: Movies/
       
        public ActionResult Index (int? id)
        {
            var movies = new List<Movie>
            {
                        new Movie() {Id = 1, Name = "Shrek"},
                        new Movie() { Id = 2, Name = "Shrek 2"},
                        new Movie() { Id = 3, Name = "Wall-e"}

            };

            
            if (id.HasValue)
            {
                return Content(string.Format("wybrałeś film z numerze ID równym {0}", id));
            }

            //return Content("nie bybałeś żadnego konkretnego filmu");
            return View(movies);

        }
    }
}