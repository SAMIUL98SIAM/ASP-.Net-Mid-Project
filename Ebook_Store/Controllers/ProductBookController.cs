using Ebook_Store.Auth;
using Ebook_Store.Models.Database;
using Ebook_Store.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ebook_Store.Controllers
{
    [SuperAdminAccess]
    public class ProductBookController : Controller
    {
        // GET: ProductBook
        //private EbookEntities2 db = new EbookEntities2();
        public ActionResult Index()
        {
            EbookEntities2 db = new EbookEntities2();
            var productBooks = db.ProductBooks.ToList();
            return View(productBooks);
        }

        // GET: ProductBook/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductBook/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View(new ProductBookModel());
        }

        // POST: ProductBook/Create
        [HttpPost]
        public ActionResult Create(ProductBookModel productBook)
        {
            
            EbookEntities2 db = new EbookEntities2();
            var pb = new ProductBook();
            pb.Name = productBook.Name;
            pb.Price = productBook.Price;
            pb.Author = productBook.Author;
            pb.Category = productBook.Category;
            pb.Quantity = productBook.Quantity;
            pb.Date = productBook.Date;
            pb.Status = 0;
            pb.Admin_Id = productBook.Admin_Id;
            pb.Seller_Id = productBook.Seller_Id;
            db.ProductBooks.Add(pb);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }


        public ActionResult Activate(int id)
        {

            EbookEntities2 db = new EbookEntities2();
            //var pb = new ProductBook();
            ProductBook pb = (from o in db.ProductBooks
                              where o.Id == id
                              select o).FirstOrDefault();
            pb.Status = 1;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
      
        public ActionResult Unactivate(int id)
        {
            EbookEntities2 db = new EbookEntities2();
            //var pb = new ProductBook();
            ProductBook pb = (from o in db.ProductBooks
                              where o.Id == id
                              select o).FirstOrDefault();
            pb.Status = 0;

            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int? id)
        {
            EbookEntities2 db = new EbookEntities2();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBook productBook = db.ProductBooks.Find(id);
            if (productBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.Admin_Id = new SelectList(db.Admins, "Id", "Name", productBook.Admin_Id);
            ViewBag.Id = new SelectList(db.OrderDetails, "Id", "Address", productBook.Id);
            ViewBag.Seller_Id = new SelectList(db.Sellers, "Id", "Name", productBook.Seller_Id);
            return View(productBook);
        }

        // POST: ProductBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Author,Category,Quantity,Status,Process,Date,Admin_Id,Seller_Id")] ProductBook productBook)
        {
            EbookEntities2 db = new EbookEntities2();
            if (ModelState.IsValid)
            {
                db.Entry(productBook).State = (System.Data.Entity.EntityState)EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Admin_Id = new SelectList(db.Admins, "Id", "Name", productBook.Admin_Id);
            ViewBag.Id = new SelectList(db.OrderDetails, "Id", "Address", productBook.Id);
            ViewBag.Seller_Id = new SelectList(db.Sellers, "Id", "Name", productBook.Seller_Id);
            return View(productBook);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            EbookEntities2 db = new EbookEntities2();
            var pd = (from sel in db.ProductBooks where sel.Id == id select sel).FirstOrDefault();
            return View(pd);
        }

        [HttpPost]
        public ActionResult Delete(Admin up_pd)
        {
            EbookEntities2 db = new EbookEntities2();
            var pd = (from sel in db.ProductBooks where sel.Id == up_pd.Id select sel).FirstOrDefault();
            db.ProductBooks.Remove(pd);
            db.SaveChanges();
            return RedirectToAction("Index", "ProductBook");
        }

        /*
        // GET: ProductBooks/Edit/5
       

        // GET: ProductBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBook productBook = db.ProductBooks.Find(id);
            if (productBook == null)
            {
                return HttpNotFound();
            }
            return View(productBook);
        }

        // POST: ProductBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductBook productBook = db.ProductBooks.Find(id);
            db.ProductBooks.Remove(productBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        */

    }
}
