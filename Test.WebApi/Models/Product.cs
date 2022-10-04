using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.WebApi.Models
{
    /*Properties*/
    public class Product
    {
        [Range(0, 13)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Category { get; set; }

        [Range(0, 999)]
        public decimal Price { get; set; }

        public Product(int id, string n, string c, decimal p)
        {
            Id = id;
            Name = n;
            Category = c;
            Price = p;
        }
    }
}