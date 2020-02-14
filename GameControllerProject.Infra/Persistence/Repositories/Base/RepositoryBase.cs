using GameControllerProject.Domain.Entities.Base;
using GameControllerProject.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GameControllerProject.Infra.Persistence.Repositories.Base
{
    public class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId> 
        where TEntity : EntityBase 
        where TId : struct
    {
        protected readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> AddList(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                _context.Set<TEntity>().Add(item);
            }
            return entities;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public bool Exists(Func<TEntity, bool> func)
        {
            return _context.Set<TEntity>().Any(func);
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAndOrderBy<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(TId id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetOrderedBy<TKey>(Expression<Func<TEntity, TKey>> order, bool ascending)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
