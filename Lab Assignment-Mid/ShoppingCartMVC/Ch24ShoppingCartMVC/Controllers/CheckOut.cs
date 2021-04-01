using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: /CheckOut/

        public CartModel cart = new CartModel();

        public ActionResult Index()
        {
            CartViewModel model = (CartViewModel)TempData["cart"];
            if (model == null)
            {
                model = cart.GetCart();
                
            }

          /*  foreach(var item in model)
            {
                TempData["tPrice"] = (int)(TempData["tPrice"] + (item.UnitPrice * item.Quantity));
            }*/

            return View(model);
        }

    }
}
