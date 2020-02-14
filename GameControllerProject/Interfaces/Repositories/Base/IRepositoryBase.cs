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

        void Delete(TEntity entity);

        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> GetAndOrderBy<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties);

        bool Exists(Func<TEntity, bool> func);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetOrderedBy<TKey>(Expression<Func<TEntity, TKey>> order, bool ascending);

        TEntity GetById(TId id);

        IEnumerable<TEntity> AddList(IEnumerable<TEntity> entities);
    }
}
