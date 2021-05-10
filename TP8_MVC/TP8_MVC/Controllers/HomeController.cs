using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP8_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Esta es la página del TP8 - MVC";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Sobre mi:";

            return View();
        }
    }
}