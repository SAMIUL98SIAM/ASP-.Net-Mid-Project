using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ebook_Store.Auth;
using Ebook_Store.Models.Database;
using Ebook_Store.Models.Entities;

namespace Ebook_Store.Controllers
{
    public class AboutController : Controller
    {
        [SuperAdminAccess]    

        // GET: Abouts
        public ActionResult Index()
        {
            EbookEntities2 db = new EbookEntities2();
            return View(db.Abouts.ToList());
        }

      
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AboutModel about)
        {
            EbookEntities2 db = new EbookEntities2();
            if (ModelState.IsValid)
            {
                var ab = new About();
                ab.Description = about.Description; 
                db.Abouts.Add(ab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EbookEntities2 db = new EbookEntities2();
            var about = (from ad in db.Abouts where ad.Id == id select ad).FirstOrDefault();
            return View(about);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(About up_about)
        {
            EbookEntities2 db = new EbookEntities2();
            var about = (from b in db.Abouts where b.Id == up_about.Id select b).FirstOrDefault();
            db.Entry(about).CurrentValues.SetValues(up_about);
            db.SaveChanges();
            return RedirectToAction("Index", "About");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            EbookEntities2 db = new EbookEntities2();
            var about = (from ad in db.Abouts where ad.Id == id select ad).FirstOrDefault();
            return View(about);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(Admin up_about)
        {
            EbookEntities2 db = new EbookEntities2();
            var about = (from b in db.Abouts where b.Id == up_about.Id select b).FirstOrDefault();
            db.Abouts.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index", "About");
        }

    }
}
