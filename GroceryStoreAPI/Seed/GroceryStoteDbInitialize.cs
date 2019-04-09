using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.Seed
{
    public class GroceryStoteDbInitialize : DropCreateDatabaseAlways<GroceryStoreDbContext>
    {
        protected override void Seed(GroceryStoreDbContext context)
        {
            IList<Product> products = new List<Product>();

            ProductType Food = new ProductType() { Name = "Food" };
            ProductType Drink = new ProductType() { Name = "Drink" };

            products.Add(new Product() { Name = "Bread", Price = 50, Type = Food });
            products.Add(new Product() { Name = "Egg", Price = 10, Type = Food });
            products.Add(new Product() { Name = "Unga", Price = 100, Type = Food });
            products.Add(new Product() { Name = "sugar", Price = 120, Type = Food });
            products.Add(new Product() { Name = "Rice", Price = 110, Type = Food });
            products.Add(new Product() { Name = "milk", Price = 60, Type = Drink });
            products.Add(new Product() { Name = "Soda", Price = 40, Type = Drink });
            products.Add(new Product() { Name = "juice", Price = 250, Type = Drink });
            products.Add(new Product() { Name = "water", Price = 100, Type = Drink });

            context.Products.AddRange(products);
            base.Seed(context);
        }
    }
}