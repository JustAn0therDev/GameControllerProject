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

        public new Player Add(Player playerToBeAdded)
        {
            return _context.Players.Add(playerToBeAdded);
        }

        public Player Authenticate(string email, string password)
        {
            return _context.Players.Find(email, password);
        }

        public new IQueryable<Player> GetAll()
        {
            return _context.Players.AsQueryable();
        }

        public Player GetByEmail(string email)
        {

            return _context.Players.Where(w => w.Email.Address == email).FirstOrDefault();

        }

        public new void Delete(Player player)
        {
            _context.Players.Remove(player);
            _context.SaveChanges();
        }

        public Player GetPlayerById(Guid id)
        {
            return _context.Players.Find(id);
        }

        public Player GetByEmailAndEncryptedPassword(string email, string password)
        {
            return _context.Players
                .Where(w => w.Email.Address == email && w.Password == password)
                .FirstOrDefault();
        }

        public void ModifyPlayer(Player playerToBeModified)
        {
            var result = _context.Players.Find(playerToBeModified.Id);
            if (result != null)
            {
                result = playerToBeModified;
                _context.SaveChanges();
            }
        }
    }
}
