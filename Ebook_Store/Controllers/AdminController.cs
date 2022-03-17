using Ebook_Store.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;
using Ebook_Store.Models.Entities;
using Ebook_Store.Auth;

namespace Ebook_Store.Controllers
{
   [SuperAdminAccess]

    public class AdminController : Controller
    {
        
        // GET: Admin
        public ActionResult Index()
        { 
            EbookEntities2 db = new EbookEntities2();
            var admins = db.Admins.ToList();
            return View(admins);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new AdminModel());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(AdminModel admin)
        { 
            if (ModelState.IsValid)
            {
                EbookEntities2 db = new EbookEntities2();
                var adm = new Admin();
                adm.Name = admin.Name;
                adm.Password = admin.Password;
                adm.DOB = admin.DOB;
                adm.Email = admin.Email;
                adm.Phone = admin.Phone;
                adm.Address = admin.Address;  
                adm.Type = "Admin";
                db.Admins.Add(adm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();       
        }

        // GET: Admin/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EbookEntities2 db = new EbookEntities2();
            var admin = (from ad in db.Admins where ad.Id == id select ad).FirstOrDefault();
            return View(admin);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Admin up_admin)
        {
            EbookEntities2 db = new EbookEntities2();
            var admin = (from b in db.Admins where b.Id == up_admin.Id select b).FirstOrDefault();
            up_admin.Type = "Admin";
            db.Entry(admin).CurrentValues.SetValues(up_admin);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        // GET: Admin/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            EbookEntities2 db = new EbookEntities2();
            var admin = (from ad in db.Admins where ad.Id == id select ad).FirstOrDefault();
            return View(admin);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(Admin up_admin)
        {
            EbookEntities2 db = new EbookEntities2();
            var admin = (from b in db.Admins where b.Id == up_admin.Id select b).FirstOrDefault();
            db.Admins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }


        
    }
}
