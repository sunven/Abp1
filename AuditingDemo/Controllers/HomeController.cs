using System;
using System.Web.Mvc;

namespace AuditingMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var a = 0;
            for (var i = 0; i < 10000; i++)
            for (var j = 0; j < 10000; j++)
                a = i - j;
            ViewBag.A = a;
            return View();
        }

        public ActionResult About()
        {
            var a = Convert.ToInt32("a");
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}