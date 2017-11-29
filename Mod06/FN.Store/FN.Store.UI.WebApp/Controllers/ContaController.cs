using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FN.Store.Domain.Helpers;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using FN.Store.UI.WebApp.Models;
using FN.Store.Data.EF;

namespace FN.Store.UI.WebApp.Controllers
{
    public class ContaController : Controller
    {

        private readonly StoreDataContext _ctx =
            new StoreDataContext();

        public ActionResult Login(string returnUrl)
        {
            ViewBag.url = returnUrl;
            return View(new LoginVM());
        }

        [HttpPost]
        public ActionResult Login(LoginVM login)
        {
            var usuario = _ctx.Usuarios.FirstOrDefault(u => u.Email.ToLower() == login.Email.ToLower());

            if (usuario == null)
                ModelState.AddModelError("Email", "Email não localizado");
            else
            {
                if (usuario.Senha != login.Senha.Encrypt())
                    ModelState.AddModelError("Senha", "Senha incorreta");
                
                if (!usuario.Status)
                    ModelState.AddModelError("", "Usuário Desativado");
            }

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(login.Email, false);

                if (!string.IsNullOrEmpty(login.Url) && Url.IsLocalUrl(login.Url))
                {
                    return Redirect(login.Url);
                }

                return RedirectToAction("Index", "Home");
            }
            return View(login);

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
