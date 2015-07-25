using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EngineerInDev.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Template")]
        public ActionResult Template(string id)
        {
            switch (id.ToLower())
            {
                case "about":
                    return PartialView("~/Views/Home/Aboutme.cshtml");
                case "index":
                    return PartialView("~/Views/Home/Home.cshtml");
                default:
                    throw new Exception("template not known");
            }
        }
    }
}
