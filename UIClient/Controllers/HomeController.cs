using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.LinkBase = ConfigurationManager.AppSettings["RedirectUrl"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.LinkBase = ConfigurationManager.AppSettings["RedirectUrl"];

            return View();
        }
    }
}