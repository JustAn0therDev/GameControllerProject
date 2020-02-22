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
        Game GetByName(string name);
        List<Game> GetGamesByGenre(string genre);
        List<Game> GetGamesByProductor(string productor);
        List<Game> GetGamesByPublisher(string publisher);
    }
}
