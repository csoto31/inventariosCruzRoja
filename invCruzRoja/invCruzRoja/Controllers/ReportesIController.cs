using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace invCruzRoja.Controllers
{
    [Authorize]
    public class ReportesIController : Controller
    {
        // GET: ReportesI
        public ActionResult Index()
        {
            return View();
        }
    }
}