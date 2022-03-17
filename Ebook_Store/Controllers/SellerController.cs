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
    
    public class SellerController : Controller
    {
        // GET: Seller
        public ActionResult Index()
        {
            EbookEntities2 db = new EbookEntities2();
            var sellers = db.Sellers.ToList();
            return View(sellers);
        }

        // GET: Seller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Seller/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new SellerModel());
        }

        // POST: Seller/Create
        [HttpPost]
        public ActionResult Create(SellerModel seller)
        {
            if (ModelState.IsValid)
            {
                EbookEntities2 db = new EbookEntities2();
                var sell = new Seller();
                sell.Name = seller.Name;
                sell.Password = seller.Password;
                sell.DOB = seller.DOB;
                sell.Email = seller.Email;
                sell.Phone = seller.Phone;
                sell.Address = seller.Address;
                sell.Admin_Id = (int?)Session["Id"];
                db.Sellers.Add(sell);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Seller/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EbookEntities2 db = new EbookEntities2();
            var seller = (from sel in db.Sellers where sel.Id == id select sel).FirstOrDefault();
            return View(seller);
        }

        // POST: Seller/Edit/5
        [HttpPost]
        public ActionResult Edit(Seller up_seller)
        {
            EbookEntities2 db = new EbookEntities2();
            var seller = (from sel in db.Sellers where sel.Id == up_seller.Id select sel).FirstOrDefault();
            
            db.Entry(seller).CurrentValues.SetValues(up_seller);
            db.SaveChanges();
            return RedirectToAction("Index", "Seller");
        }

        // GET: Seller/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            EbookEntities2 db = new EbookEntities2();
            var seller = (from sel in db.Sellers where sel.Id == id select sel).FirstOrDefault();
            return View(seller);
        }

        // POST: Seller/Delete/5
        [HttpPost]
        public ActionResult Delete(Admin up_seller)
        {
            EbookEntities2 db = new EbookEntities2();
            var seller = (from sel in db.Sellers where sel.Id == up_seller.Id select sel).FirstOrDefault();
            db.Sellers.Remove(seller);
            db.SaveChanges();
            return RedirectToAction("Index", "Seller");
        }
    }
}