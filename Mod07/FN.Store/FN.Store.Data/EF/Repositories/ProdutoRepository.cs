using FN.Store.Domain.Contracts;
using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Repositories
{
    public class ProdutoRepository:Repository<Produto>, IProdutoRepository
    {

        public IEnumerable<Produto> GetByName(string nome)
        {
            return
                //from p in _ctx.Produto
                //where p.Nome.Contains(nome)
                //select p;
                _ctx.Produto.Where(p=>p.Nome.Contains(nome)).ToList();
        }
    }
}
