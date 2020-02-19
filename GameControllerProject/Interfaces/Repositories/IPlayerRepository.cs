using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Repositories.Base;
using System;

namespace GameControllerProject.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository : IRepositoryBase<Player, Guid>
    {
        Player GetByEmailAndEncryptedPassword(string email, string password);
    }
}
