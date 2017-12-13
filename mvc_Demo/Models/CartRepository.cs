using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_Demo.Models
{
    public class CartRepository
    {
        private List<Product> products = (List<Product>)HttpContext.Current.Session["cart"];
        

        public IQueryable<Product> GetAll()
        {
            return products.AsQueryable();
        }

        public void AddItem(Product product)
        {
            products.Add(product);
            HttpContext.Current.Session["cart"] = products;
        }

        public void DeleteItem(int id)
        {
            products.Remove(products.Where(p => p.Id == id).FirstOrDefault());
            HttpContext.Current.Session["cart"] = products;
        }
    }
}