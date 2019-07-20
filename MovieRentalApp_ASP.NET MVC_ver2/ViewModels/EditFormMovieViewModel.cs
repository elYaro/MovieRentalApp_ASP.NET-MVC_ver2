using MovieRentalApp_ASP.NET_MVC_ver2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalApp_ASP.NET_MVC_ver2.ViewModels
{
    public class EditFormMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}