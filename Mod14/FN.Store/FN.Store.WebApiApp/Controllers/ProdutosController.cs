using FN.Store.Data.EF.Repositories;
using FN.Store.Domain.Contracts;
using FN.Store.Domain.Entities;
using FN.Store.WebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FN.Store.WebApiApp.Controllers
{
    public class ProdutosController : ApiController
    {
        private readonly IProdutoRepository _prodRep;

        public ProdutosController()
        {
            _prodRep = new ProdutoRepository();
        }

        public IEnumerable<Produto> Get()
        {
            return _prodRep.GetWithTipos();
        }

        public async Task<HttpResponseMessage> Get(int id)
        {
            var produto = await _prodRep.GetAsync(id);

            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request
                    .CreateResponse(HttpStatusCode.OK, produto);


        }

        public HttpResponseMessage Post(ProdutoVM model)
        {
            //checar se o preco é um decimal
            decimal _preco;
            if (!string.IsNullOrEmpty(model.Preco) && !decimal.TryParse(model.Preco, out _preco))
                ModelState.AddModelError("Preco", "Preco inválido");

            if (ModelState.IsValid)
            {
                _prodRep.Insert(new Produto {
                    Nome= model.Nome,
                    Preco = Convert.ToDecimal(model.Preco),
                    TipoProdutoId = model.TipoProdutoId,
                    Descricao = model.Descricao
                });
                return Request
                    .CreateResponse(HttpStatusCode.OK, model);
            }

            return Request
                    .CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }


        public HttpResponseMessage Put(int id, ProdutoVM model)
        {
            //checar se o preco é um decimal
            decimal _preco;
            if (!string.IsNullOrEmpty(model.Preco) && !decimal.TryParse(model.Preco, out _preco))
                ModelState.AddModelError("Preco", "Preco inválido");

            if (ModelState.IsValid)
            {
                _prodRep.Edit(new Produto
                {
                    Id = id,
                    Nome = model.Nome,
                    Preco = Convert.ToDecimal(model.Preco),
                    TipoProdutoId = model.TipoProdutoId,
                    Descricao = model.Descricao
                });
                return Request
                    .CreateResponse(HttpStatusCode.OK, model);
            }

            return Request
                    .CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var produto = await _prodRep.GetAsync(id);

            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            _prodRep.Delete(produto);

            return Request
                    .CreateResponse(HttpStatusCode.NoContent);


        }


        protected override void Dispose(bool disposing)
        {
            _prodRep.Dispose();
        }
    }
}