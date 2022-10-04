using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.WebApi.Models
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> products = new List<Product>()
        {
           new Product( 0,"Povrtna juha",  "Namirnice",  4.50M ),
            new Product ( 1, "Plasticna figurica", "Igracke", 13.99M),
            new Product (2, "Cekic", "Alat",  49.99M)
        };
        private int _nextId = 3;

        public ProductRepository()
        {
           
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        [HttpGet]
        public Product Get(int id)
        {
            return products.Find(p => p.Id == id);
        }

        [HttpPost]
        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            products.Add(item);       
            return item;
        }

        [HttpDelete]
        public void Remove(int id)
        {
            products.RemoveAll(p => p.Id == id);
        }

        [HttpPut]
        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = products.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            products.Remove(products.First(i => i.Id == item.Id));
            products.Add(item);
            return true;
        }
    }
}