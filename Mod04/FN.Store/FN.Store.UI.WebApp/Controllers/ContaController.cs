using FN.Store.UI.WebApp.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FN.Store.UI.WebApp.Helpers;
using System.Web.Security;

namespace FN.Store.UI.WebApp.Controllers
{
    public class ContaController : Controller
    {

        private readonly StoreDataContext _ctx =
            new StoreDataContext();

        public ActionResult Login(string returnUrl)
        {
            ViewBag.url = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string senha, string url)
        {
            var usuario = _ctx.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            if (usuario.Senha != senha.Encrypt())
            {
                throw new Exception("Senha incorreta");
            }

            FormsAuthentication.SetAuthCookie(email, false);

            if (!string.IsNullOrEmpty(url) && Url.IsLocalUrl(url))
            {
                return Redirect(url);
            }

            return RedirectToAction("Index", "Home");

        }

        public ActionResult MeuPerfil()
        {
            var email = User.Identity.Name;
            var usuario = _ctx.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            return View(usuario);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public JsonResult AlterarSenha(string senha)
        {
            var email = User.Identity.Name;
            var status = true;
            var mensagem = "senha alterada com sucesso";

            var usuario = _ctx.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            if (usuario == null || string.IsNullOrEmpty(senha))
            {
                status = false;
                mensagem = "não foi possível alterar a senha";
            }
            else
            {
                usuario.Senha = senha.Encrypt();
                _ctx.SaveChanges();
            }

            return Json(new { status = status, mensagem = mensagem });

        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }

    }
}
