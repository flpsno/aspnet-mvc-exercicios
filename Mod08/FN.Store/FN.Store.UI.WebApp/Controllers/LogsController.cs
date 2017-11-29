using FN.Store.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FN.Store.UI.WebApp.Controllers
{
    public class LogsController:Controller
    {
        private readonly StoreDataContext _ctx =
            new StoreDataContext();

        public ActionResult Index()
        {
            var logs = _ctx.Usuarios.FirstOrDefault(x => x.Email == User.Identity.Name).Logs;
            return View(logs);
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }
    }
}