using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebook_Store.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SuperAdminAccess : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var auth = false;
            if (httpContext.Session["Email"] != null)
            {
                auth = true;
            }
            if (auth && httpContext.Session["Type"].Equals("SuperAdmin"))
            {
                return true;
            }
            return false;
            
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/Home/Index");
            
        }
    }
}