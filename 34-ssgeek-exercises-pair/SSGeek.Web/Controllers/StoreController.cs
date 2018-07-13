using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;
using SSGeek.Web.Extensions;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class StoreController : Controller
    {
        private IProductDAL dal;
        private const string Session_Key = "User_Cart";

        public StoreController(IProductDAL dal)
        {
            this.dal = dal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = dal.GetProducts();

            return View(products);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var p = dal.GetProduct(id);
            var sci = new ShoppingCartItem() { Product=p};
            return View(sci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(ShoppingCartItem item)
        {
            var cart = GetShoppingCart();
            // call the DAL to prevent price manipulation
            var itemToAdd = dal.GetProduct(item.Product.Id);
            // make the corresponding product the item to add to our cart
            item.Product = itemToAdd;
            cart.AddToCart(item.Product, item.Quantity);

            // save the cart to session
            HttpContext.Session.Set(Session_Key, cart);

            // keep users on the page
            return RedirectToAction("viewcart");
        }

        public ShoppingCart GetShoppingCart()
        {
            ShoppingCart cart = HttpContext.Session.Get<ShoppingCart>(Session_Key);

            if (cart == null)
            {
                // create a cart if it doesn't exist
                cart = new ShoppingCart();
                // this saves our shopping cart in the current session
                HttpContext.Session.Set(Session_Key, cart);
            }

            return cart;
        }
    }
}