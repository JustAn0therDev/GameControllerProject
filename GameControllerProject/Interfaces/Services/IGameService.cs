using System;
using System.Collections.Generic;
using System.Text;
using GameControllerProject.Domain.Interfaces.Services.Base;
using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Arguments.Game;
using GameControllerProject.Domain.Arguments.CustomTypes;

namespace GameControllerProject.Domain.Interfaces.Services
{
    public interface IGameService : IServiceBase 
    {
        AddGameResponse AddGame(AddGameRequest request);
        ModifyGameResponse ModifyGame(ModifyGameRequest request);
        DeleteGameResponse DeleteGame(DeleteGameRequest request);
        GetAllGamesResponse GetAllGames();
        GameWithPlatform GetById(Game game);
        Game GetByName(string name);
        GetGameResponse GetGamesByProductor(string productor);
        GetGameResponse GetGamesByPublisher(string publisher);
        GetGameResponse GetGamesByGenre(string genre);
    }
}
