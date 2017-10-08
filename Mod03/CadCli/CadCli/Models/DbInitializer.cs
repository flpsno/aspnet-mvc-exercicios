using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CadCli.Models
{
    public class DbInitializer : CreateDatabaseIfNotExists<CadCliDataContext>
    {
        protected override void Seed(CadCliDataContext context)
        {

            context.Clientes.AddRange(new List<Cliente>() { 
        
                    new Cliente(){Nome="Fabiano",Idade=38},
                    new Cliente(){Nome="Raphael",Idade=18},
                    new Cliente(){Nome="Priscila",Idade=39},
                    new Cliente(){Nome="Nair",Idade=69}
                }
            );

            context.SaveChanges();


        }
    }
}