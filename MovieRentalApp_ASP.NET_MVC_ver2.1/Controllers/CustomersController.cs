using MovieRentalApp_ASP.NET_MVC_ver2._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentalApp_ASP.NET_MVC_ver2._1.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetAllCustomers();
            return View(customers);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return new List<Customer> {
                
                new Customer {
                    Name = "Bolek Bolkowski",
                    Id = 1},
                new Customer {
                    Name = "Lolek Lolkowski",
                    Id= 2}
                    
            };
        }

        //GET: Customers/Details/1
        public ActionResult Details(int id)
        {
            var customer = GetAllCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}