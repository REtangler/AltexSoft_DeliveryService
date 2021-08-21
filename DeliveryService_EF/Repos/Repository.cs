using System;
using System.Linq;
using System.Linq.Expressions;
using AltexFood_Delivery.DAL.Data;
using AltexFood_Delivery.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AltexFood_Delivery.DAL.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbFactory _dbFactory;
        private DbSet<T> _dbSet;

        protected DbSet<T> DbSet => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());

        public Repository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public IQueryable<T> List(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }
    }
}
