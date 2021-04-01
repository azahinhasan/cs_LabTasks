using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Controllers {
    public class HomeController : Controller

    {
        //Models.InventoryDbEntities context = new Models.InventoryDbEntities();

        [HttpGet]
        public ViewResult Index() {
            TempData["Total"] = 0;
            ViewBag.HeaderText = "Welcome to the Halloween Store";
            ViewData["FooterText"] = "Where every day is Halloween!";
            return View();
        }
        [HttpGet]
        public ViewResult Contact() {
            //CREATE A ContactViewModel OBJECT call model  model 
            //Pass model to View

            ContactViewModel model = new ContactViewModel();

            return View(model);
        }
    }
}
