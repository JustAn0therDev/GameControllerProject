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

        public void Delete(Guid Id)
        {
            var result = _context.Games.Find(Id);
            _context.Games.Remove(result);
            _context.SaveChanges();
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

        public Game GetById(Guid id)
        {
            return _context.Games.Find(id);
        }

        public Game GetByName(string name)
        {
            return _context.Games.Find(name);
        }

        public List<Game> GetGamesByGenre(string genre)
        {
            return _context.Games.Where(w => w.Genre.ToLower() == genre.ToLower()).ToList();
        }

        public List<Game> GetGamesByProductor(string productor)
        {
            return _context.Games.Where(w => w.Productor.ToLower() == productor.ToLower()).ToList();
        }

        public List<Game> GetGamesByPublisher(string publisher)
        {
            return _context.Games.Where(w => w.Publisher.ToLower() == publisher.ToLower()).ToList();
        }

        public IQueryable<Game> GetOrderedBy<TKey>(Expression<Func<Game, TKey>> order, bool ascending)
        {
            throw new NotImplementedException();
        }

        public new Game Update(Game entity)
        {
            var game = _context.Games.Find(entity.Id);
            game = entity;
            _context.SaveChanges();

            return game;
        }
    }
}
