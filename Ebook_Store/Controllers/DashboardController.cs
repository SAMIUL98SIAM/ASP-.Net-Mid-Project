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
    [AdminAccess]
    public class DashboardController : Controller
    {
        public ActionResult Admin()
        {
            EbookEntities2 db = new EbookEntities2();
            var orders = db.Orders.ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderModel>();
                cfg.CreateMap<Customer, CustomerModel>();
            }
            );
            var mapper = new Mapper(config);
            var data = mapper.Map<List<OrderModel>>(orders);
            return View(data);
        }
    }
}