using Ebook_Store.Models.Database;
using Ebook_Store.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ebook_Store.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminModel admin)
        {
            if (ModelState.IsValid)
            {
                var db = new EbookEntities2();
                var u = (from e in db.Admins
                         where e.Email.Equals(admin.Email) &&
                         e.Password.Equals(admin.Password)
                         select e).FirstOrDefault();
                if (u != null)
                {
                    Session["Name"] = u.Name;
                    Session["Email"] = u.Email;
                    Session["Type"] = u.Type;
                    if (u.Type.Equals("Admin"))
                    {
                        return RedirectToAction("Admin", "Dashboard");
                    }
                    else if (u.Type.Equals("SuperAdmin"))
                    {
                        return RedirectToAction("Dashboard", "SuperAdmin");
                    }
                }
                else
                {
                    ViewBag.Message = "Password does not match";
                }
            }
            return View();
        }


       
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}