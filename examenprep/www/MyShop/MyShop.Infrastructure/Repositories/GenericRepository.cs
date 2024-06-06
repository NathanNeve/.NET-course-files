using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private ShoppingContext _shoppingContext;
        private DbSet<T> table = null;

        public GenericRepository(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
            table = _shoppingContext.Set<T>();
        }
        public virtual T Add(T obj)
        {
            table.Add(obj);
            return obj;
        }

        public virtual IEnumerable<T> All()
        {
            return table.ToList();
        }

        public virtual T Get(int id)
        {
            return table.Find(id);
        }

        public virtual T Update(T obj)
        {
            table.Update(obj);
            return obj;
        }
        public void SaveChanges()
        {
            _shoppingContext.SaveChanges();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = table;

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }
    }
}
