using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Contracts
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetByName(string nome);
    }
}
