using FN.Store.UI.WebApp.Data.EF;
using FN.Store.UI.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FN.Store.UI.WebApp.Filters
{
    public class LogAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var action = filterContext.ActionDescriptor.ActionName;
                var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                var email = HttpContext.Current.User.Identity.Name;

                using (var ctx = new StoreDataContext())
                {
                    var log = new Log() { 
                        Local = controller + "/" + action,
                        UsuarioId = ctx.Usuarios.FirstOrDefault(u=>u.Email==email).Id
                    };

                    ctx.Logs.Add(log);
                    ctx.SaveChanges();
                }

            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }
}