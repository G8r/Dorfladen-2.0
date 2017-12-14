using mvc_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace mvc_Demo.Controllers
{
    public class CartController : Controller
    {
        private readonly CartRepository _cartRepository = new CartRepository();
        private readonly ProductRepository _productRepository = new ProductRepository();
        private decimal _total = 0;

        /// <summary>
        /// GET: Cart
        /// Returns a view of the actual shopping cart
        /// </summary>
        /// <returns>View with Model of IQueryable of Type Product</returns>
        public ActionResult Index() => View("Cart", _cartRepository.GetAll());

        /// <summary>
        /// GET: Cart/Add
        /// Add's the Product with the id from the parameter into the cart and store the result in the Session variable "CartItemAmount"
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View with Model of IQueryable of Type Product</returns>
        public ActionResult Add(int id)
        {
            var product = _productRepository.GetById(id);
            var cartItems = _cartRepository.GetAll();

            //Check if the product is already in the cart
            if (cartItems.ToList().Exists(p => p.Name == product.Name))
            {
                cartItems.Where(p => p.Name == product.Name).ToList().ForEach(a => a.Amount++);
            }
            else
            {
                _cartRepository.AddItem(product);
            }

            //update total items
            Session["cartItemAmount"] = (int)Session["cartItemAmount"] + 1;

            var updatedCartItems = _cartRepository.GetAll();
            ViewBag.Total = GetTotalPrice(updatedCartItems);

            return View("Cart", updatedCartItems);
        }

        /// <summary>
        /// GET: Cart/Delete
        /// Delete the Product with the id from the parameter and store the result in the Session variable "CartItemAmount"
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View with Model of IQueryable of Type Product</returns>
        public ActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            var cartItems = _cartRepository.GetAll();

            //Check if the products name already exists in the shopping-cart and it has more then one item of it
            if (cartItems.First(n => n.Name == product.Name).Amount > 1)
            {
                cartItems.Where(p => p.Name == product.Name).ToList().ForEach(a => a.Amount--);
            }
            else
            {
                _cartRepository.DeleteItem(id);
            }

            //update the amount of shopping-cart items
            Session["cartItemAmount"] = (int)Session["cartItemAmount"] - 1;

            var updatedCartItems = _cartRepository.GetAll();
            ViewBag.Total = GetTotalPrice(updatedCartItems);

            return View("Cart", updatedCartItems);
        }

        /// <summary>
        /// Calculates and returns the total price of the shopping-cart
        /// </summary>
        /// <param name="items">Requires a parameter of IQueryable with type Product </param>
        /// <returns>dynamic object</returns>
        private decimal GetTotalPrice(IQueryable<Product> items)
        {
            foreach (var item in items)
            {
                _total += item.Amount * item.SpecialPrice;
            }
            return _total;
        }
    }
}
