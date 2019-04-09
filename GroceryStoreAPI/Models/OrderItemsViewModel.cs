using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryStoreAPI.Models
{
    public class OrderItemsViewModel
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
    }
}