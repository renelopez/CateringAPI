﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.DataLayer
{
    public abstract class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbSet = context.Set<T>();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = _dbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public T Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public T Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}