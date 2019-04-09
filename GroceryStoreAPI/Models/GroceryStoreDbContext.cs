using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GroceryStoreAPI.Models
{
    public class GroceryStoreDbContext : DbContext
    {
        public GroceryStoreDbContext() : base("GroceryStoreDbContext")
        {
            //Database.SetInitializer(new Seed.GroceryStoteDbInitialize());
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<SalesTransactions> CerealSales { get; set; }
        
    }
}