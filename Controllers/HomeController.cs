using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filtros.Controllers
{
    [CustomActionFilter]
    public class HomeController : Controller
    {
        // GET: Home
        //[CustomActionFilter]
        public ActionResult Index()
        {
            return View();
        }

        //[CustomActionFilter]
        public ActionResult Message()
        {
            return Content("Hello, World!!!");
        }
    }
}