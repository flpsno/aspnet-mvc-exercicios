using FN.Store.UI.WebApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FN.Store.Test.WebApp.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        //Dado o controller HomeController

        [TestMethod]
        [TestCategory("Controllers")]
        public void O_método_Index_deverá_retornar_a_view_Index()
        { 
            //arrange
            var controller = new HomeController();

            //a
            var index = controller.Index() as ViewResult;

            //a
            Assert.AreEqual("Index", index.ViewName);
        }
    }
}
