using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FN.Store.UI.WebApp.Controllers
{
    public class JQueryUIController : Controller
    {
        public ActionResult Index()
        {
            

            return View();
        }


        public JsonResult Linguagens()
        {
            var availableTags = new string[]{
              "ActionScript",
              "AppleScript",
              "Asp",
              "BASIC",
              "CSharp",
              "C",
              "C++",
              "Clojure",
              "COBOL",
              "ColdFusion",
              "Erlang",
              "Fortran",
              "Groovy",
              "Haskell",
              "Java",
              "JavaScript",
              "Lisp",
              "Perl",
              "PHP",
              "Python",
              "Ruby",
              "Scala",
              "Scheme"
            };
            return Json(availableTags,JsonRequestBehavior.AllowGet);
        }
    }
}