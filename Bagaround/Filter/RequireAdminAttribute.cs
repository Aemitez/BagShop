using Bagaround.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bagaround.Filter
{
    public class RequireAdminAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                var routeValue = new RouteValueDictionary
                {
                    ["controller"] = "Login",
                    ["action"] = "Login"
                };
                filterContext.Result = new RedirectToRouteResult(routeValue);
            }
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (SessionMenager.UserId == "false" || SessionMenager.UserId == null||SessionMenager.Role == "User")
                return false;
            else
            {
                return true;
            }
        }

    }
}