using Ebook_Store.Models.Database;
using Ebook_Store.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using System.Net;

namespace Ebook_Store.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EbookEntities2 db = new EbookEntities2();
            var productBooks = db.ProductBooks.ToList();
            return View(productBooks);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            EbookEntities2 db = new EbookEntities2();
            var abouts= db.Abouts.ToList();
            return View(abouts);
        }
        //Mail
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
      
                using (MailMessage mail = new MailMessage("samiulsiam59@gmail.com", model.Too))
                {
                    mail.Subject = model.Subject;
                    mail.Body = model.Body;
                    mail.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;

                        NetworkCredential nc = new NetworkCredential("samiulsiam59@gmail.com","Siam38844-3");
                        smtp.UseDefaultCredentials = true;

                        smtp.Credentials = nc;
                        smtp.Port = 587;

                        smtp.Send(mail);

                        ViewBag.Message = "Email Sent Successfully";
                    }
                }
            }
          return View();
        }
    }
}