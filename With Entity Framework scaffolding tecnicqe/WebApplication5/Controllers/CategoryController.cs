using WebApplication5.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using System.Data.Entity;

namespace WebApplication5.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        Models.InventoryDbEntities context = new Models.InventoryDbEntities();



        public ActionResult Index()
        {
            return View(context.Catagories.ToList());
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Catagory category )
        {
            context.Catagories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit( int id)
        {
            var categoryToEdit = context.Catagories.Find(id); //find only for Primery key
            //var categoryToEdit = context.Catagories.Where(x => x.CateforyName=="cloth").FirstOrdDefult(); //for others
            
            return View(categoryToEdit);
        }

        [HttpPost]
        public ActionResult Edit(int id,Catagory category)
        {
            category.CatagoriesId = id;
            var categoryToEdit = context.Catagories.Find(id);
            
            categoryToEdit.CatagoriesName = category.CatagoriesName;
            //context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]   
        public ActionResult Delete(int id)
        {
            var categoryToEdit = context.Catagories.Find(id);
            return View(categoryToEdit);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            context.Catagories.Remove(context.Catagories.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}