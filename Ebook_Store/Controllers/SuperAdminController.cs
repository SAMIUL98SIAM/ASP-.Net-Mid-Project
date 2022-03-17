using AutoMapper;
using Ebook_Store.Auth;
using Ebook_Store.Models.Database;
using Ebook_Store.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebook_Store.Controllers
{
    [SuperAdminAccess]
    public class SuperAdminController : Controller
    {
        // GET: SuperAdmin

        public ActionResult Dashboard()
        {
            EbookEntities2 db = new EbookEntities2();
            var orderDetails = db.OrderDetails.ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDetail, OrderDetailModel>();
                cfg.CreateMap<Order, OrderModel>();
                cfg.CreateMap<ProductBook, ProductBookModel>();
                cfg.CreateMap<Customer, CustomerModel>();

            }
            );
            var mapper = new Mapper(config);
            var data = mapper.Map<List<OrderDetailModel>>(orderDetails);
            return View(data);
        }
        [HttpGet]
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
        public ActionResult About()
        {
            return View(new AboutModel());
        }

        // POST: Seller/Create
        [HttpPost]
        public ActionResult About(AboutModel about)
        {
            if (ModelState.IsValid)
            {
                EbookEntities2 db = new EbookEntities2();
                var abt = new About();
                abt.Description = about.Description;
                db.Abouts.Add(abt);
                db.SaveChanges();
                return RedirectToAction("Dasboard");
            }
            return View();
        }

    }
}