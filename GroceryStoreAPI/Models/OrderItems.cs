using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GroceryStoreAPI.Models
{
    public class OrderItems
    {
        [Key]
        [ForeignKey("Product")]
        public int OrderItemId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public int Total { get; set; }

        public virtual Product Product { get; set; }

        public int SalesTransactionsId { get; set; }
        public SalesTransactions SalesTransactions { get; set; }
    }
}