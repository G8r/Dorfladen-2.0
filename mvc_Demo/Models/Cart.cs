using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_Demo.Models
{
    public class Cart
    {
        private List<Product> products;

        public Cart(List<Product> products)
        {
            this.Products = products;
        }

        public List<Product> Products { get => products; set => products = value; }
    }
}