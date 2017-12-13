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
        private ProductRepository repository = new ProductRepository();
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.Title = "";
            var products = repository.GetAll();

            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id = 1)
        {
            ViewBag.Title = $"- {@ControllerContext.RouteData.Values["Action"].ToString()}";
            var product = repository.GetByID(id);

            return View(product);
        }
    }
}
