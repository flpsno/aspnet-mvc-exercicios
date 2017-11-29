using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Contracts
{
    public interface IRepository<T> : IDisposable
        where T : Entity
    {
        //CRUD
        T Insert(T entity);
        T Edit(T entity);

        IEnumerable<T> Get();
        T Get(int id);

        void Delete(T entity);


    }
}
