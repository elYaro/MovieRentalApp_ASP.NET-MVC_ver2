using AutoMapper;
using MovieRentalApp_ASP.NET_MVC_ver2.Dtos;
using MovieRentalApp_ASP.NET_MVC_ver2.Models;
using System;
using System.Data.Entity;
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
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }
            

        // GET/api/customers/1
        public IHttpActionResult GetCustomer (int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST/api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer (CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();


            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT/api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer (int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }
            Mapper.Map(customerDto, customerInDb);

            //customerIdDb.Name = customerDto.Name;
            //customerIdDb.BirthDate = customerDto.BirthDate;
            //customerIdDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            //customerIdDb.MembershipTypeId = customerDto.MembershipTypeId;

            _context.SaveChanges();

            return Ok();
        }


        //DELETE/api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer (int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }

}

