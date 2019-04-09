using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryStoreAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [JsonIgnore]
        public ProductType Type { get; set; }

        [Required]
        public decimal Price { get; set; }

        [JsonIgnore]
        public virtual OrderItems OrderItems { get; set; }

    }
}