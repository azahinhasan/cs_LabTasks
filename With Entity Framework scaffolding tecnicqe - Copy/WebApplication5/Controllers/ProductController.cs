using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Models.InventoryDbEntities context = new Models.InventoryDbEntities();
        public ActionResult Index()
        {
            return View(context.Products.ToList());
            //return View(context.Products.Find()); //for 1 or selected products
        }

        [HttpGet]

        public ActionResult Create()
        {

            ViewData["catagories"] = context.Catagories.ToList();
            return View();
        }

        [HttpPost]

        public ActionResult Create(Product product)
        {
            /* if (product.ProductsName==null)
             {
                 ViewData["error"] = "Product Name not Given";
                 ViewData["catagories"] = context.Catagories.ToList();
                 return View();
             }
             else
             {
                 context.Products.Add(product);
                 context.SaveChanges();
                 return RedirectToAction("Index");
             }*/

            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["catagories"] = context.Catagories.ToList();
            return View();

        }


        [HttpGet]

        public ActionResult Editt(int id)
        {
            ViewData["catagories"] = context.Catagories.ToList();
            return View(context.Products.Find(id));
        }


        [HttpPost]

        public ActionResult Edit(int id,Product product)
        {
            product.ProductsId = id;
            context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Delete(int id)
        {
            return View(context.Products.Find(id));
        }


        [HttpPost,ActionName("Delete")]

        public ActionResult ConfirmDelete(int id, Product product)
        {
            context.Products.Remove(context.Products.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult TopTwoProducts()
        {
            var list = context.Products.OrderByDescending(x => x.Price).Take(2).ToList();
            // ^Its called Lambda Expression

            /*var list= from item in context.Products
                      orderby item.Price descending
                      select item;
            return View(list.Take(2));*/
            return View(list.Take(2));
        }

    }
}