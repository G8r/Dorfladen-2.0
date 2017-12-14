using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Mvc;
using mvc_Demo.Models;

namespace mvc_Demo.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository = new ProductRepository();
        
        /// <summary>
        /// GET: Product
        /// Returns the main view with all the products in the web-shop
        /// </summary>
        /// <returns>View with a List of type Product</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "";
            var products = _repository.GetAll();

            return View(products);
        }

        /// <summary>
        /// GET: Product/Details/5
        /// Returns a detail view of the clicked Product
        /// </summary>
        /// <param name="id">The id for the Product to get</param>
        /// <returns>View with a Product</returns>
        public ActionResult Details(int? id = 1)
        {
            ViewBag.Title = $"- {@ControllerContext.RouteData.Values["Action"].ToString()}";
            var product = _repository.GetById(id);

            return View(product);
        }
    }
}
