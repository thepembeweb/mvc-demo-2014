using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Demo.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/Details?productId=1

        [AllowAnonymous]
        public ActionResult Details(int productId)
        {
            return View(productId);
        }
    }
}