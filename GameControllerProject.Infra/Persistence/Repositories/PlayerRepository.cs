using GameControllerProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using GameControllerProject.Infra.Persistence.Repositories.Base;

namespace GameControllerProject.Infra.Persistence.Repositories
{
    class PlayerRepository : RepositoryBase<Player, Guid>
    {
        private readonly new GameControllerProjectContext _context;

        public PlayerRepository(GameControllerProjectContext context) : base(context)
        {
            _context = context;
        }

        public Player AddPlayer(Player playerToBeAdded)
        {
            try
            {
                using (var db = _context)
                {
                    var result = db.Players.Add(playerToBeAdded);

                    if (result != null)
                        db.SaveChanges();

                    return result;
                }
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

        public List<Player> GetAllPlayers()
        {
            try
            {
                //Habilita paralelismo na query. Útil para queries maiores e mais complexas.
                return _context.Players.AsParallel().ToList();
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
