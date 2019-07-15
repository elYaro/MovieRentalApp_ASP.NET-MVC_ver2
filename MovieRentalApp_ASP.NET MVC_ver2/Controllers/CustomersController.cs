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
            var customers = GetAllCustomers();
            return View(customers);
        }


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

        // GET: Cutomers/Details/{id}
        public ActionResult Details(int id)
        {
            var customer = GetAllCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }


        }








    }
}
