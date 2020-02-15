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
            return _context.Set<TEntity>().Select(s => s);
        }

        public IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntity>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntity> GetAndOrderBy<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return ascendente ? Get(includeProperties).OrderBy(ordem) : Get(includeProperties).OrderByDescending(ordem);
        }

        public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Get(includeProperties).Where(expression);
        }

        public TEntity GetById(TId id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetOrderedBy<TKey>(Expression<Func<TEntity, TKey>> order, bool ascending)
        {
            return ascending ? _context.Set<TEntity>().OrderBy(order) : _context.Set<TEntity>().OrderByDescending(order);
        }

        public TEntity Update(TEntity entity)
        {
            using (var result = _context.Set<TEntity>().Find(entity.Id))
            {
                if (result != null)
                    _context.SaveChanges();
            }
            return entity;
        }

        /// <summary>
        /// Realiza include populando o objeto passado por parametro
        /// </summary>
        /// <param name="query">Informe o objeto do tipo IQuerable</param>
        /// <param name="includeProperties">Ínforme o array de expressões que deseja incluir</param>
        /// <returns></returns>
        private IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
    }
}
