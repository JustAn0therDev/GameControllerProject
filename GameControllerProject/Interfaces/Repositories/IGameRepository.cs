using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;

namespace GameControllerProject.Domain.Interfaces.Repositories
{
    public interface IGameRepository : IRepositoryBase<Game, Guid>
    {
        Game AddGame(Game game);
        List<Game> GetAllGames();
    }
}
