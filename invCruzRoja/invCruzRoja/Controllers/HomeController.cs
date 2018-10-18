using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace invCruzRoja.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Empleados()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Inventarios()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Territorios()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Charlie()
        {
            return View();
        }
        public ActionResult Christopher()
        {
            return View();
        }
        public ActionResult Diego()
        {
            return View();
        }
        public ActionResult Maria()
        {
            return View();
        }

        public ActionResult Cristian()
        {
            return View();
        }

        public ActionResult Carlos()
        {
            return View();
        }

    }
}