using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace invCruzRojaMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "TI-ICR: Inventariado Cruz Roja";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Cruz Roja Costarricence.";

            return View();
        }

        public ActionResult Territorios()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        
    }
}