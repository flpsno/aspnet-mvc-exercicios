using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FN.Store.UI.WebApp.Models;

namespace FN.Store.UI.WebApp.Data.EF
{
    public class DbInitializer:CreateDatabaseIfNotExists<StoreDataContext>
    {
        protected override void Seed(StoreDataContext context)
        {

            var vestuario = new TipoProduto() { Nome = "Vestuário" };
            var higiene = new TipoProduto() { Nome = "Higiene" };
            var alimento = new TipoProduto() { Nome = "Alimento" };

            context.Produto.AddRange(
                new List<Produto>() { 
                    new Produto(){Nome="Camisa Esportiva",Preco=199.99M,TipoProduto=vestuario},
                    new Produto(){Nome="Tenis Nike",Preco=204.85M, TipoProduto=vestuario},
                    new Produto(){Nome = "Picanha congelada", Preco=50.44M, TipoProduto=alimento},
                    new Produto(){Nome = "Pasta de dente colgate", Preco=20, TipoProduto=higiene}
                    }
                );

            context.SaveChanges();

        }
    }
}