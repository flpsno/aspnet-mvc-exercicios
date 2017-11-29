using FN.Store.Domain.Contracts;
using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Repositories
{
    public class Repository<T>:IRepository<T>
        where T: Entity
    {
        protected readonly StoreDataContext _ctx =
            new StoreDataContext();

        public T Insert(T entity)
        {
            _ctx.Set<T>().Add(entity);
            salvarNaBase();
            return entity;
        }

        public T Edit(T entity)
        {
            _ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            salvarNaBase();
            return entity;
        }

        public IEnumerable<T> Get()
        {
            return _ctx.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            salvarNaBase();
        }


        private void salvarNaBase()
        {
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }


        public async Task<T> GetAsync(int id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }
    }
}
