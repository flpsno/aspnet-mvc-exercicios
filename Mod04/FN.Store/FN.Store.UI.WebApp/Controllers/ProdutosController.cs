using FN.Store.UI.WebApp.Data.EF;
using FN.Store.UI.WebApp.Filters;
using FN.Store.UI.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FN.Store.UI.WebApp.Controllers
{

    [Authorize, LogAttribute]
    public class ProdutosController : Controller
    {

        private readonly StoreDataContext _ctx =
            new StoreDataContext();

        public ActionResult Index()
        {
            var clientes = _ctx.Produto.ToList();
            return View(clientes);
        }

        //[HttpGet] tanto faz colocar get, é o default
        public ActionResult Add()
        {
            obterTipos();
            return View("AddEdit", new Produto());
        }

        private void obterTipos()
        {
            ViewBag.Tipos = _ctx.TipoProdutos.ToList();
        }

        [HttpPost]
        public ActionResult Add(Produto produto)
        {
            _ctx.Produto.Add(produto);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var produto = _ctx.Produto.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            obterTipos();
            return View("AddEdit", produto);
        }

        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            _ctx.Entry(produto).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Del(int id)
        {
            var excluido = true;
            var mensagem = "Excluído c/ sucesso";

            var prod = _ctx.Produto.Find(id);
            if (prod == null)
            {
                excluido = false;
                mensagem = "Produto não encontrado";
            }
            else
            {
                _ctx.Produto.Remove(prod);
                _ctx.SaveChanges();
            }

            return Json(new { status = excluido, msg = mensagem });
        }

        [AllowAnonymous]
        public string Teste()
        {
            return "Página aberta";
        }


        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }

    }
}
