using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityPortalApp.Core;
using UniversityPortalApp.Data;

namespace UniversityPortalApp.Web
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void  OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (UniversityContext db = new UniversityContext())
            {
                ActionLog log = new ActionLog()
                {
                    Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    Action = string.Concat(filterContext.ActionDescriptor.ActionName, "(Logged by CustomActionFilter)"),
                    IP = filterContext.HttpContext.Request.UserHostAddress,
                    Date = filterContext.HttpContext.Timestamp
                };
                db.ActionLog.Add(log);
                db.SaveChanges();
                base.OnActionExecuting(filterContext);
            }
        }
    }
}