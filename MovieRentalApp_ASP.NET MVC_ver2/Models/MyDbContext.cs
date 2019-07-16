using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieRentalApp_ASP.NET_MVC_ver2.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public DbSet<Customer> Customers { get; set; }

    }
}
