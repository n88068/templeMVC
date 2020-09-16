using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using templeMVC.Models;

namespace templeMVC.Controllers
{
    public class DbTestController : Controller
    {
        // GET: DbTest
        public ActionResult Index()
        {
            DBmanager dBmanager = new DBmanager();
            List<Member> members = dBmanager.GetMembers();
            ViewBag.members = members;
            return View();
        }
        public ActionResult CreateMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMember(Member member)
        {
            DBmanager dBmanager = new DBmanager();
            try {
                dBmanager.NewMember(member);
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            return RedirectToAction("Index");
        }
    }
}