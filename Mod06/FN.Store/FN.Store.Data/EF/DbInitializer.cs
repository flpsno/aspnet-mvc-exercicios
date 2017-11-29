using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FN.Store.Domain.Helpers;

namespace FN.Store.Data.EF
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
