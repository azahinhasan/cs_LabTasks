using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFast.Models;

namespace CodeFast.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        InventoryDbContext dbContext = new InventoryDbContext();

        public ActionResult Index()
        { 
            var list = dbContext.Categories.ToList();
            return View(list);
        }
    }
}