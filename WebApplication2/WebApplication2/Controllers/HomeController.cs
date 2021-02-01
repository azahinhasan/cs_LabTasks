using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public string Index(int? id) //nullable type 'int?'
        {
            return "hellow"+id;
        }


    }
}