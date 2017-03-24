using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityPortalApp.Data;
using UniversityPortalApp.Core;

namespace UniversityPortalApp.Web
{
    public class HandleExceptionsAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            using (UniversityContext db = new UniversityContext())
            {
                ErrorLog er = new ErrorLog()
                {
                    Message = filterContext.Exception.Message,
                    StackTrace = filterContext.Exception.StackTrace,
                    HelpLink = filterContext.Exception.HelpLink,
                    Source = filterContext.Exception.Source,
                    InnerException = filterContext.Exception.InnerException != null ? filterContext.Exception.InnerException.Message : "",
                    CreatedDate = DateTime.Now
                };
                //var exception = filterContext.Exception;
                db.ErrorLog.Add(er);
                db.SaveChanges();
                base.OnException(filterContext);
            }


            //ILog log = LogManager.GetLogger("UnhandledException");
            //log.Error("Error", exception);
        }
    }
}