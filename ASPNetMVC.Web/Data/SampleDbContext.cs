using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ASPNetMVC.Web.Entities;

namespace ASPNetMVC.Web.Data
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext():base("VictorContext")
        {
                
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}