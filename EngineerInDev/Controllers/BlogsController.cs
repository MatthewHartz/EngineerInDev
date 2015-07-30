using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EngineerInDev.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        public ActionResult Index()
        {
            return View();
        }
    }
}