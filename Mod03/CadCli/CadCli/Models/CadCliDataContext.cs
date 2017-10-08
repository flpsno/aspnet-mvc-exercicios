using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CadCli.Models
{
    public class CadCliDataContext:DbContext
    {
        public CadCliDataContext()
            : base(@"Data Source=(localdb)\v11.0;Initial Catalog=CadCli;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Cliente> Clientes { get; set; }

    }
}