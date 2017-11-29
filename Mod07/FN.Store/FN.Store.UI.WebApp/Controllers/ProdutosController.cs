using FN.Store.Data.EF;
using FN.Store.Data.EF.Repositories;
using FN.Store.Domain.Contracts;
using FN.Store.Domain.Entities;
using FN.Store.UI.WebApp.Filters;
using FN.Store.UI.WebApp.Models;
using Newtonsoft.Json;
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

        private readonly IProdutoRepository _prodRep;
        private readonly IRepository<TipoProduto> _tipoRep;

        public ProdutosController()
        {
            _prodRep = new ProdutoRepository();
            _tipoRep = new Repository<TipoProduto>();
        }

        //IoC => Inversão de Controle
        public ProdutosController(IProdutoRepository prodRep, IRepository<TipoProduto> tipoRep)
        {
            _prodRep = prodRep;
            _tipoRep = tipoRep;
        }


        public ActionResult Index()
        {
            var clientes = _prodRep.Get();
            return View("Index",clientes);
        }

        //[HttpGet] tanto faz colocar get, é o default
        public ActionResult Add()
        {
            obterTipos();
            return View("AddEdit", new Produto());
        }

        private void obterTipos()
        {
            ViewBag.Tipos = _tipoRep.Get();
        }

        [HttpPost]
        public ActionResult Add(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _prodRep.Insert(produto);
                return RedirectToAction("Index");
            }

            obterTipos();
            return View("AddEdit", produto);
        }

        public ActionResult Edit(int id)
        {
            var produto = _prodRep.Get(id);

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
            if (ModelState.IsValid)
            {
                _prodRep.Edit(produto);
                return RedirectToAction("Index");
            }
            obterTipos();
            return View("AddEdit", produto);
        }

        [HttpPost]
        public JsonResult Del(int id)
        {
            var excluido = true;
            var mensagem = "Excluído c/ sucesso";

            var prod = _prodRep.Get(id);
            if (prod == null)
            {
                excluido = false;
                mensagem = "Produto não encontrado";
            }
            else
            {
                _prodRep.Delete(prod);
            }

            return Json(new { status = excluido, msg = mensagem });
        }

        [AllowAnonymous]
        public string Teste()
        {
            return "Página aberta";
        }

        //[Route("Produtos/ObterPorNome/{nome}")]
        public string ObterPorNome(string nome)
        {
            var prods = _prodRep.GetByName(nome).Count().ToString();
            return prods;
        }


        protected override void Dispose(bool disposing)
        {
            _prodRep.Dispose();
            _tipoRep.Dispose();
        }

    }
}
