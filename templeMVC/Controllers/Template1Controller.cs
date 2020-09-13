using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace templeMVC.Controllers
{
    public class Template1Controller : Controller
    {
        // GET: Template1
        public ActionResult Index()
        {
            return View();
        }
    }
}