using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult MyMethod(int? id) //nullable type
        {
            Console.WriteLine("Hello");
           return RedirectToAction("Another", new {id}); //new{} anonymous obj
        }
        public ActionResult Another(int? id)
        {
            //return Content("From Aother Mehotd "+id);
            return RedirectToAction("Index","Person");
        }
    }
}