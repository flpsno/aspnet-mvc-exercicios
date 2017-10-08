using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoGlobalizacao.Controllers
{
    public class CadastroController : Controller
    {
        //
        // GET: /Cadastro/

        public ActionResult Index()
        {
            return View();
        }

        public string Salvar(string nome, string idade)
        {
            return string.Format("Nome: {0} - Idade: {1}",nome, idade);
        }

    }
}
