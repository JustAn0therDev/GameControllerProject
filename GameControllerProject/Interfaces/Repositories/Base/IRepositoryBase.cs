using GameControllerProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GameControllerProject.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity, TId> where TEntity : class where TId : struct
    {
        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(TId id);

        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> GetAndOrderBy<TKey>(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetById(TId id);

        bool Exists(Expression<Func<TEntity, bool>> func);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetOrderedBy<TKey>(Expression<Func<TEntity, TKey>> order, bool ascending);
    }
}
