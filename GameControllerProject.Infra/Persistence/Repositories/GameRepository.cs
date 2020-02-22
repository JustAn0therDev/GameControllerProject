using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Infra.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GameControllerProject.Infra.Persistence.Repositories
{
    public class GameRepository : RepositoryBase<Game, Guid>, IGameRepository
    {
        #region Private Members

        private readonly GameControllerProjectContext _context;

        #endregion

        #region Constructors

        public GameRepository(GameControllerProjectContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        public Game Add(Game entity)
        {
            throw new NotImplementedException();
        }

        public Game AddGame(Game entity)
        {
            _context.Games.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public new IQueryable<Game> AddList(IEnumerable<Game> entities)
        {
            throw new NotImplementedException();
        }

        public new void Delete(Game entity)
        {
            throw new NotImplementedException();
        }

        public new bool Exists(Func<Game, bool> func)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Game> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Game> GetAllGames()
        {
            return _context.Games.Select(s => s).ToList();
        }

        public IQueryable<Game> GetAndOrderBy<TKey>(Expression<Func<Game, bool>> where, Expression<Func<Game, TKey>> ordem, bool ascendente = true, params Expression<Func<Game, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Game> GetBy(Expression<Func<Game, bool>> where, params Expression<Func<Game, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public new Game GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Game> GetOrderedBy<TKey>(Expression<Func<Game, TKey>> order, bool ascending)
        {
            throw new NotImplementedException();
        }

        public Game Update(Game entity)
        {
            throw new NotImplementedException();
        }
    }
}
