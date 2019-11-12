using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class NWContext : DbContext
    {
        public NWContext(DbContextOptions<NWContext> options) :base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Customer> Customers { get; set; }
        //public DbSet<Test> Tests { get; set; }

        public DbSet<ProductReview> ProductReviews { get; set; }
    }
}
