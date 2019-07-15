using MovieRentalApp_ASP.NET_MVC_ver2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentalApp_ASP.NET_MVC_ver2.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            /*var customers1 = new List<Customer>()
            {
               
            };
            */
            var customers = GetAllCustomers();
            return View(customers);
        }

            // var customers = new 


        private IEnumerable<Customer> GetAllCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Bolek"},
                new Customer {Id = 2, Name = "Lolek"},
                new Customer {Id = 3, Name = "Tola"},
                new Customer {Id = 4, Name = "Uszatek"}
            };
        }






            

    }
}
