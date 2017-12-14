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
        /// <summary>
        /// GET: Home/About
        /// Returns a View with the project information
        /// </summary>
        /// <returns>View</returns>
        public ActionResult About()
        {
            ViewBag.Title = $"- {@ControllerContext.RouteData.Values["Action"].ToString()}";
            return View();
        }

        /// <summary>
        /// GET: Home/Contact
        /// Returns a View with contact informations
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Contact()
        {
            ViewBag.Title = $"- {@ControllerContext.RouteData.Values["Action"].ToString()}";
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// GET: HOME/M133Aufgabenanforderung
        /// Returns a pdf with the project description of the module 133
        /// </summary>
        /// <returns>PDF</returns>
        public ActionResult M133Aufgabenanforderungen()
        {
            return File("~/Assets/pdf/m133Projektbeschrieb.pdf", "application/pdf");
        }

        /// <summary>
        /// GET: HOME/M426Aufabenanforderungen
        /// Returns a pdf with the project description of the module 426
        /// </summary>
        /// <returns>PDF</returns>
        public ActionResult M426Aufgabenanforderungen()
        {
            return File("~/Assets/pdf/m426Arbeitsauftrag.pdf", "application/pdf");
        }
    }
}