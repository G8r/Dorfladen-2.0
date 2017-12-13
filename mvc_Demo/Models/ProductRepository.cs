using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace mvc_Demo.Models
{
    public class ProductRepository
    {
        #region Source
        List<Product> _products = new List<Product>();

        public ProductRepository()
        {
            GetProductsFromCSV();
        }

        /// <summary>
        /// Reads the content from products.csv and createa a product-object foreach line except the first one which conatains the column description
        /// and add it to a List<>
        /// </summary>
        private void GetProductsFromCSV()
        {
            string PathToProductsCSV = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets/csv/products.csv");

            using (StreamReader Sr = new StreamReader(PathToProductsCSV))
            {
                int LineCounter = 0;
                string CurrentLine;

                while ((CurrentLine = Sr.ReadLine()) != null)
                {
                    if (LineCounter != 0)
                    {
                        string[] product = CurrentLine.Split(';');
                        _products.Add(
                            new Models.Product(
                                Convert.ToInt32(product[0]),
                                product[1],
                                Convert.ToDecimal(product[2]),
                                Convert.ToDecimal(product[3]),
                                product[4], product[5])
                        );
                    }
                    LineCounter++;
                }
            }
        }
        #endregion

        public IQueryable<Product> GetAll()
        {
            return _products.AsQueryable();
        }

        public Product GetByID(int? id)
        {
            return _products.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}