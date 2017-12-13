using mvc_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_Demo.Controllers
{
    public class CartController : Controller
    {
        private CartRepository _cartRepository = new CartRepository();
        private ProductRepository _productRepository = new ProductRepository();
        private decimal total = 0;

        // GET: Cart
        public ActionResult Index()
        {
            return View("Cart", _cartRepository.GetAll());
        }

        public ActionResult Add(int id)
        {

            var products = _productRepository.GetAll();
            var product = products.Where(p => p.Id == id).FirstOrDefault();
            var cartItems = _cartRepository.GetAll();
            int totalItems = (int)Session["cartItemAmount"];

            //Check if the product is already in the cart
            if (cartItems.Count(n => n.Name == product.Name) >= 1)
            {
                cartItems.Where(p => p.Name == product.Name).ToList().ForEach(a => a.Amount++);
            }
            else
            {
                _cartRepository.AddItem(product);
            }

            //update total items
            totalItems++;
            Session["cartItemAmount"] = totalItems;

            var updatedCartItems = _cartRepository.GetAll();
            ViewBag.Total = GetTotal(updatedCartItems);

            return View("Cart", updatedCartItems);
        }

        public ActionResult Delete(int id)
        {
            var products = _productRepository.GetAll();
            var product = products.Where(p => p.Id == id).FirstOrDefault();
            var cartItems = _cartRepository.GetAll();
            int totalItems = (int)Session["cartItemAmount"];

            //Check if the product is already in the cart
            if (cartItems.Count(n => n.Name == product.Name) >= 1)
            {
                cartItems.Where(p => p.Name == product.Name).ToList().ForEach(a => a.Amount--);
            }
            else
            {
                _cartRepository.DeleteItem(id);
            }

            //update total items
            totalItems--;
            Session["cartItemAmount"] = totalItems;

            var updatedCartItems = _cartRepository.GetAll();
            ViewBag.Total = GetTotal(updatedCartItems);

            return View("Cart", cartItems);
        }

        private dynamic GetTotal(IQueryable<Product> items)
        {
            foreach (var item in items)
            {
                total += item.Amount * item.SpecialPrice;
            }
            return total;
        }
    }
}
