using System;
using System.Collections.Generic;
using System.Text;
using GameControllerProject.Domain.Interfaces.Services.Base;
using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Arguments.Game;

namespace GameControllerProject.Domain.Interfaces.Services
{
    public interface IGameService : IServiceBase 
    {
        AddGameResponse AddGame(AddGameRequest request);
        Game ModifyGame(Game game);
        void Delete(Game game);
        GetAllGamesResponse GetAllGames();
        Game GetById(Game game);
        Game GetByName(string name);
        List<Game> GetGamesByProductor(string productor);
        List<Game> GetGamesByPublisher(string publisher);
        List<Game> GetGamesByGenre(string genre);
    }
}
