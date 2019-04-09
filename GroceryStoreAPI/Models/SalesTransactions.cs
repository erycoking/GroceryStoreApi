using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryStoreAPI.Models
{
    public class SalesTransactions
    {
        [Key]
        public int SalesTransactionsId { get; set; }

        [Required]
        public int TotalCost { get; set; }

        public List<OrderItems> OrderItems { get; set; }
    }
}