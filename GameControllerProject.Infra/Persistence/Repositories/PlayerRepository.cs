using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Infra.Persistence.Repositories.Base;
using System;
using System.Linq;

namespace GameControllerProject.Infra.Persistence.Repositories
{
    public class PlayerRepository : RepositoryBase<Player, Guid>, IPlayerRepository
    {
        #region Private Members

        private readonly new GameControllerProjectContext _context;

        #endregion

        #region Public Methods

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

        public Player ModifyPlayer(Player playerToBeModified)
        {
            var result = _context.Players.Find(playerToBeModified.Id);
            if (result != null)
            {
                result = playerToBeModified;
                _context.SaveChanges();
            }
            return result; 
        }

        #endregion
    }
}
