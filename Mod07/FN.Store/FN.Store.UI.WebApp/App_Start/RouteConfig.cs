using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FN.Store.UI.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GetByName",
                url: "Produtos/ObterPorNome/{nome}",
                defaults: new { controller = "Produtos", action = "ObterPorNome" }
            );

            routes.MapRoute(
                name: "ProdutoEdit",
                url: "Produtos/{id}",
                defaults: new { controller = "Produtos", action = "Edit" },
                constraints: new { id="[0-9]+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );




        }
    }
}