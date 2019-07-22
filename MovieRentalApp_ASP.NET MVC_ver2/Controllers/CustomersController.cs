using MovieRentalApp_ASP.NET_MVC_ver2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MovieRentalApp_ASP.NET_MVC_ver2.ViewModels;

namespace MovieRentalApp_ASP.NET_MVC_ver2.Controllers
{
    public class CustomersController : Controller
    {
        private MyDbContext _context;

        public CustomersController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            return View(customers);
        }



        // GET: Cutomers/Details/{id}
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }
        // GET: Customer/New
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }


        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);


                /*
                TryUpdateModel(customerInDb);
                properties in customerInDb object will be updated based on the key-value pairs in request data. 
                This is an official Microsoft aproach suggested in ASP.NET tutorials on their page.
                I will not use this approach because of the following issues:
                1) it opens up security holes in the application: if we don't want the user to be able to update all properties in the Form but the User will be smart hacker may add additional key-value pairs in form data and with the method Hacker will update all properties.

                Microsoft proposed the solution which is using the 3rd argument with the specified properties to be updated ex : TryUpdateModel(customerInDb, "", new string[] {"Name", "Email"});
                 In this approach the problem is the magic strings. 

                So will will ue another way to updated properties...
                 */

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter; 
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        




        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }


        





    }
}
