using MovieRentalApp_ASP.NET_MVC_ver2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRentalApp_ASP.NET_MVC_ver2.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private MyDbContext _context;

        public CustomersController()
        {
            _context = new MyDbContext();
        }

        // GET/api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
            

        // GET/api/customers/1
        public Customer GetCustomer (int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
        }

        // POST/api/customers
        [HttpPost]
        public Customer CreateCustomer (Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        // PUT/api/customers/1
        [HttpPut]
        public void UpdateCustomer (int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerIdDb = _context.Customers.Single(c => c.Id == id);

            if (customerIdDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            customerIdDb.Name = customer.Name;
            customerIdDb.BirthDate = customer.BirthDate;
            customerIdDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerIdDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();

        }


        //DELETE/api/customers/1
        [HttpDelete]
        public void DeleteCustomer (int id)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();


        }
    }

}

