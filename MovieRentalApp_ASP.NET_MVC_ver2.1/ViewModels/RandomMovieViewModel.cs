using MovieRentalApp_ASP.NET_MVC_ver2._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalApp_ASP.NET_MVC_ver2._1.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
