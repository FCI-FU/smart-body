using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smart__Body.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Name = "Abdalrahman";
            return View();
        }
        
        public ActionResult Exercise()
        {
            ViewBag.Name = "Abdalrahman";
            return View();
        }

        public ActionResult AboutUs ()
        {
            ViewBag.Name = "Abdalrahman";
            return View();
        }

    }
}
