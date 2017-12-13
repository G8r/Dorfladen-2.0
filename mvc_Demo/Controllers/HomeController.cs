using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = $"- {@ControllerContext.RouteData.Values["Action"].ToString()}";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = $"- {@ControllerContext.RouteData.Values["Action"].ToString()}";
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}