using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{

    public class Person
    {
        public string Name { get; set; }
        public double Salary { get; set; }
    }


    public class MainController : Controller
    {

        List<Person> people = new List<Person>()
        {
            new Person(){ Name= "ABC" , Salary=1200},
            new Person(){ Name= "DEF" , Salary=2200}
        };
        // GET: Main

        //Data Passing techiques from controller to view
        //1.Session
        /*2.ViewData : work like local variable. container for spacific request object.
                        Work only in same funcion or controller. mostly use for Error masg*/
        //3.ViewBag : almost like ViewData
        //4.TempData
        //5.Model(ViewModel/DataModel)


        [HttpGet]

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


         public ActionResult Index()
         {
             //Person person = new Person() { Name="Person Class"};

             Session["name"] = "zahin";
             Session["Age"] = 21;
             ViewData["nameV"] = "Tamom";
             ViewBag.nameVB = "Tom";
             TempData["nameTD"] = "Jerry";

            return View();
         }

       /* public ActionResult Index(Person person)
        {
            //Person person = new Person() { Name="Person Class"};

            return Content(person.Name + "->");
        }*/
    }
}