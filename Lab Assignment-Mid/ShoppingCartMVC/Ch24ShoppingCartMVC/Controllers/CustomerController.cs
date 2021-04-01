using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        Models.HalloweenEntitiess context = new Models.HalloweenEntitiess();
        public ActionResult Index()
        {
            return View(context.Customers.ToList());
        }
       
        public ActionResult showInfo(string email)
        {
            return View(context.Customers.Find(email));
        }

        [HttpGet]

        public ActionResult Create()
        {
            ViewData["State"] = context.States.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Customer info)
        {
            
            context.Customers.Add(info);
            context.SaveChanges();
            return RedirectToAction("showInfo", new { email = info.Email });
        }

        [HttpGet]

        public ActionResult Search()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Search(Models.Customer info)
        {
            bool Valid = context.Customers.Any(x => x.Email == info.Email);
            if (Valid)
            {
                return RedirectToAction("showInfo", new { email = info.Email });
            }

            return RedirectToAction("Create");
        }


        }
}
