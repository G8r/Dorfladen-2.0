using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace mvc_Demo.Models
{
    /// <summary>
    /// The Productrepository provides methods to get all products or a product with a specific id
    /// </summary>
    public class ProductRepository
    {
        #region Source

        readonly List<Product> _products = new List<Product>();

        /// <summary>
        /// Instatiate all the products to work with
        /// </summary>
        public ProductRepository()
        {
            GetProductsFromCsv();
        }

        /// <summary>
        /// Reads the content from products.csv which was provided by the teacher and create a product-object foreach line except the first one which contains the column description
        /// and add it to a List<>
        /// </summary>
        private void GetProductsFromCsv()
        {
            var pathToProductsCsv = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets/csv/products.csv");

            using (var sr = new StreamReader(pathToProductsCsv))
            {
                var lineCounter = 0;
                string currentLine;

                while ((currentLine = sr.ReadLine()) != null)
                {
                    if (lineCounter != 0)
                    {
                        var product = currentLine.Split(';');
                        _products.Add(
                            new Models.Product(
                                Convert.ToInt32(product[0]),
                                product[1],
                                Convert.ToDecimal(product[2]),
                                Convert.ToDecimal(product[3]),
                                product[4], product[5])
                        );
                    }
                    lineCounter++;
                }
            }
        }
        #endregion

        /// <summary>
        /// Return's all Products that are available in the web-shop
        /// </summary>
        /// <returns>IQueryable of type Product</returns>
        public IQueryable<Product> GetAll()
        {
            return _products.AsQueryable();
        }

        /// <summary>
        /// Retrun's a Product whit the given id
        /// </summary>
        /// <param name="id">The id of the Product to get</param>
        /// <returns>Product</returns>
        public Product GetById(int? id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}