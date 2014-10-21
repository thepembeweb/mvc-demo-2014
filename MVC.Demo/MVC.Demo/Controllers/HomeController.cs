using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Demo.Models;

namespace MVC.Demo.Controllers
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void Nothing()
        {
        }

        [NonAction]
        public ActionResult NotAvailable()
        {
            return View();
        }

        public int AnInteger()
        {
            return 10;
        }

        public string SomeText()
        {
            return "Hello world";
        }

        public Product AProduct()
        {
            return new Product { Id = 1, Name = "Dummy product", Price = 120m };
        }
    }
}