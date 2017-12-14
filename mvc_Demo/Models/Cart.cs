using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_Demo.Models
{
    public class Cart
    {
        public Cart(List<Product> products)
        {
            this.Products = products;
        }

        public List<Product> Products { get; set; }
    }
}