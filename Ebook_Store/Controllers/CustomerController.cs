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
    
    public class CustomerController : Controller
    {
        // GET: Customer
       
        public ActionResult Index()
        {
            
            EbookEntities2 db = new EbookEntities2();
            var customer = db.Customers.ToList();
            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CustomerModel());
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                EbookEntities2 db = new EbookEntities2();
                var cus = new Customer();
                cus.Name = customer.Name;
                cus.Password = customer.Password;
                cus.DOB = customer.DOB;
                cus.Email = customer.Email;
                cus.Phone = customer.Phone;
                cus.Address = customer.Address;
                //cus.Admin_Id = (int?)Session["Id"];
                db.Customers.Add(cus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Customer/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EbookEntities2 db = new EbookEntities2();
            var customer = (from cus in db.Customers where cus.Id == id select cus).FirstOrDefault();
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer up_customer)
        {
            EbookEntities2 db = new EbookEntities2();
            var customer = (from cus in db.Customers where cus.Id == up_customer.Id select cus).FirstOrDefault();

            db.Entry(customer).CurrentValues.SetValues(up_customer);
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        // GET: Customer/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            EbookEntities2 db = new EbookEntities2();
            var customer = (from cus in db.Customers where cus.Id == id select cus).FirstOrDefault();
            return View(customer);
        }

        // POST: Seller/Delete/5
        [HttpPost]
        public ActionResult Delete(Customer up_customer)
        {
            EbookEntities2 db = new EbookEntities2();
            var customer = (from sel in db.Customers where sel.Id == up_customer.Id select sel).FirstOrDefault();
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}