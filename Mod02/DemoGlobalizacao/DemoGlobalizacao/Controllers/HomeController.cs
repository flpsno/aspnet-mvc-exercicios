using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace DemoGlobalizacao.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //var cultura = new CultureInfo("pt-br");
            var cultura = new CultureInfo("es-ar");
            //var cultura = new CultureInfo("en-us");
            Thread.CurrentThread.CurrentCulture = cultura;
            Thread.CurrentThread.CurrentUICulture = cultura;
            return View();
        }

    }
}
