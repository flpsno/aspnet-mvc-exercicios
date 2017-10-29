using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FN.Store.UI.WebApp.Models;
using FN.Store.UI.WebApp.Helpers;

namespace FN.Store.UI.WebApp.Data.EF
{
    public class DbInitializer : CreateDatabaseIfNotExists<StoreDataContext>
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


            context.Usuarios.AddRange(

                new List<Usuario> { 
                    new Usuario{Email="fabiano.nalin@gmail.com",Senha="123456".Encrypt()},
                    new Usuario{Email="nalin@fansoft.com",Senha="123456".Encrypt()},
                }

                );

            context.SaveChanges();

        }
    }
}