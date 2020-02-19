using GameControllerProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using GameControllerProject.Infra.Persistence.Repositories.Base;
using GameControllerProject.Domain.Interfaces.Repositories;

namespace GameControllerProject.Infra.Persistence.Repositories
{
    public class PlayerRepository : RepositoryBase<Player, Guid>, IPlayerRepository
    {
        private readonly new GameControllerProjectContext _context;

        public PlayerRepository(GameControllerProjectContext context) : base(context)
        {
            _context = context;
        }

        public Player Add(Player playerToBeAdded)
        {
            try
            {
                return _context.Players.Add(playerToBeAdded);
            }
            catch
            {
                throw;
            }
        }

        public Player Authenticate(string email, string password)
        {
            try
            {
                return _context.Players.Find(email, password);
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<Player> GetAll()
        {
            try
            {
                var result = _context.Players.AsQueryable();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public Player GetPlayerById(Guid id)
        {
            try
            {
                return _context.Players.Find(id);
            }
            catch
            {
                throw;
            }
        }

        public Player GetByEmailAndEncryptedPassword(string email, string password)
        {
            return _context.Players
                .Where(w => w.Email.Address == email && w.Password == password)
                .FirstOrDefault();
        }

        public void ModifyPlayer(Player playerToBeModified)
        {
            try
            {
                using (var db = new GameControllerProjectContext())
                {
                    var result = db.Players.Find(playerToBeModified.Id);
                    if (result != null)
                    {
                        result = playerToBeModified;
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
