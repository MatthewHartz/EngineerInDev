using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using EngineerInDev.Services;

namespace EngineerInDev.Controllers
{
    public class AddController : Controller
    {
        [BasicAuthenticationAttribute("rvbmrdonut", "My Password For Engineer In Dev1", BasicRealm = "EngineerInDev")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
