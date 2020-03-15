using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Infra.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameControllerProject.Infra.Persistence.Repositories
{
    public class GameRepository : RepositoryBase<Game, Guid>, IGameRepository
    {
        #region Private Members

        private new readonly GameControllerProjectContext _context;

        #endregion

        #region Constructors

        public GameRepository(GameControllerProjectContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        public Game AddGame(Game entity)
        {
            _context.Games.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid Id)
        {
            var result = _context.Games.Find(Id);
            _context.Games.Remove(result);
            _context.SaveChanges();
        }

        public List<Game> GetAllGames()
        {
            return _context.Games.Select(s => s).ToList();
        }

        public new Game GetById(Guid id)
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

        public new Game Update(Game entity)
        {
            var game = _context.Games.Find(entity.Id);
            game = entity;
            _context.SaveChanges();

            return game;
        }

        #endregion
    }
}
