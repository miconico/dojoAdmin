using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DojoTest.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Attendance()
        {
            return View();
        }

        public ActionResult DojoClass()
        {
            return View();
        }

        public ActionResult Mentors()
        {
            return View();
        }

        public ActionResult CreatingTables()
        {
            return View();
        }

        public ActionResult ForeignKeys()
        {
            return View();
        }

        public ActionResult EntityFramework()
        {
            return View();
        }

        public ActionResult NinjaAppServices()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}