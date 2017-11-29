using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Caching;

namespace FN.Store.UI.WebApp.Controllers
{
    public class TesteCacheController : Controller
    {

        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            var model = new Random().Next(0, 10);
            return View(model);
        }

        public ActionResult MemCache()
        {
            var random = new Random().Next(0, 10);
            var model = MemoryCache.Default.AddOrGetExisting("random", random, DateTime.Now.AddSeconds(10));
            ViewBag.Num = new Random().Next(100, int.MaxValue);
            return View(model ?? random);
        }

    }
}