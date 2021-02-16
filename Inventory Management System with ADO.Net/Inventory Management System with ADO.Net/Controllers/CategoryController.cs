using Inventory_Management_System_with_ADO.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_System_with_ADO.Net.Controllers
{
    public class CategoryController : Controller
    {
        CategoryModel categoryModel = new CategoryModel();
        public ActionResult Index()
        {
            return View(categoryModel.GetCategories());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryModel.Insert(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(categoryModel.GetCategory(id));
        }
        [HttpPost]
        public ActionResult Edit(int id,Category category)
        {
            category.CategoryId = id;
            categoryModel.Update(category);
            return RedirectToAction("Index");
        }
    }
}