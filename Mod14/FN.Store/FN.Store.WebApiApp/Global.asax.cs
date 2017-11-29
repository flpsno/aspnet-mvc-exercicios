using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace FN.Store.WebApiApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;

            //Remove o XML
            formatters.Remove(formatters.XmlFormatter);

            //Config. o json de resposta
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;

            //Deixa a resposta identada e mais amigável (apenas p/ seres humanos)
            jsonSettings.Formatting = Formatting.Indented;

            //Deixa a serialização dos objetos em CamelCase (Default na Web)
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //Evita o loop infinito no case de objetvos encadeados
            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                ReferenceLoopHandling.Ignore;


            GlobalConfiguration.Configuration.Routes.MapHttpRoute(

                name: "Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id=RouteParameter.Optional}

            );
        }

        
    }
}