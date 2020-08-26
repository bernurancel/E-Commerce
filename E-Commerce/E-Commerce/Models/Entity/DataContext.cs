using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using E_Commerce.Models.Entity;

namespace E_Commerce.Entity
{
    public class DataContext:DbContext
    {
        public DataContext() : base("dataConnection") 
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet <Brand> Brands { get; set; }
        public DbSet <Shipper> Shippers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}