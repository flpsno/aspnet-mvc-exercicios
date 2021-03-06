﻿using FN.Store.UI.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FN.Store.UI.WebApp.Data.EF
{
    public class StoreDataContext : DbContext
    {
        public StoreDataContext():base("StoreConn")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Log> Logs { get; set; }

    }
}