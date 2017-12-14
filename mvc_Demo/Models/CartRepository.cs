using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_Demo.Models
{
    /// <summary>
    /// The Cartrepository class provides methods to get, add or delete shopping cart items
    /// </summary>
    public class CartRepository
    {
        private readonly List<Product> _products = (List<Product>)HttpContext.Current.Session["cart"];
        
        /// <summary>
        /// Returns all items in the shopping cart
        /// </summary>
        /// <returns>IQueryable of type Product</returns>
        public IQueryable<Product> GetAll()
        {
            return _products.AsQueryable();
        }

        /// <summary>
        /// Add's an item of type Product to the shopping cart
        /// </summary>
        /// <param name="product">The Product to add</param>
        public void AddItem(Product product)
        {
            _products.Add(product);
            HttpContext.Current.Session["cart"] = _products;
        }

        /// <summary>
        /// Delete's an item from the shopping cart
        /// </summary>
        /// <param name="id">The id of the Product to delete</param>
        public void DeleteItem(int id)
        {
            _products.Remove(_products.FirstOrDefault(p => p.Id == id));
            HttpContext.Current.Session["cart"] = _products;
        }
    }
}