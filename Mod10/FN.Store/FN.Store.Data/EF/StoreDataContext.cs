using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.EF
{
    public class StoreDataContext : DbContext
    {
        public StoreDataContext()
            : base("StoreConn")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Log> Logs { get; set; }

    }
}
