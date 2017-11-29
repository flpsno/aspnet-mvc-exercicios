using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FN.Store.UI.WebApp.Controllers
{
    public class HomeController : Controller
    {
        [HandleError(ExceptionType=typeof(Exception),View="xpto")]
        public ActionResult Index()
        {
            //throw new Exception("Deu ruim");
            return View("Index");
        }

    }
}
