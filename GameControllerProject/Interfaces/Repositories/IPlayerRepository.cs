using System;
using GameControllerProject.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GameControllerProject.Domain.Interfaces.Repositories.Base;

namespace GameControllerProject.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository : IRepositoryBase<Player, Guid>
    {
        Player Authenticate(string email, string password);
    }
}
