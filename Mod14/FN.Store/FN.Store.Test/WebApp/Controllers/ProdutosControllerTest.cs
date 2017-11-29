using FN.Store.Domain.Contracts;
using FN.Store.Domain.Entities;
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
    public class ProdutosControllerTest
    {
        //Dado o controller ProdutosController

        [TestMethod]
        public void O_metodo_index_devera_retornar_a_view_Index_com_a_lista_de_produtos()
        {
            //a
            var controller = new ProdutosController(new ProdRepo(), new TipoProdRepo());

            //a
            var index = controller.Index() as ViewResult;

            //a
            Assert.AreEqual("Index", index.ViewName);
            Assert.AreEqual(typeof(List<Produto>), index.Model.GetType());
        }
    }

    class ProdRepo : IProdutoRepository
    {
        public IEnumerable<Domain.Entities.Produto> GetByName(string nome)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Produto Insert(Domain.Entities.Produto entity)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Produto Edit(Domain.Entities.Produto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Entities.Produto> Get()
        {
            var vestuario = new TipoProduto() { Nome = "Vestuário" };
            var higiene = new TipoProduto() { Nome = "Higiene" };
            var alimento = new TipoProduto() { Nome = "Alimento" };

            return
                new List<Produto>() { 
                    new Produto(){Nome="Camisa Esportiva",Preco=199.99M,TipoProduto=vestuario},
                    new Produto(){Nome="Tenis Nike",Preco=204.85M, TipoProduto=vestuario},
                    new Produto(){Nome = "Picanha congelada", Preco=50.44M, TipoProduto=alimento},
                    new Produto(){Nome = "Pasta de dente colgate", Preco=20, TipoProduto=higiene}
                    };
        }

        public Domain.Entities.Produto Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Domain.Entities.Produto entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public Task<Produto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Produto> GetWithTipos()
        {
            throw new NotImplementedException();
        }
    }
    class TipoProdRepo : IRepository<TipoProduto>
    {
        public TipoProduto Insert(TipoProduto entity)
        {
            throw new NotImplementedException();
        }

        public TipoProduto Edit(TipoProduto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoProduto> Get()
        {
            throw new NotImplementedException();
        }

        public TipoProduto Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TipoProduto entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public Task<TipoProduto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
