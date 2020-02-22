using GameControllerProject.Domain.Arguments.Game;
using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;

namespace GameControllerProject.Domain.Services
{
    public class GameService : Notifiable, IGameService
    {
        #region Private Members

        private readonly IGameRepository _gameService;

        #endregion

        #region Constructors

        public GameService(IGameRepository gameService)
        {
            _gameService = gameService;
        }

        #endregion

        #region Public Methods 

        public AddGameResponse AddGame(AddGameRequest request)
        {
            try
            {
                var game = new Game(request.Name, request.Productor, request.Publisher, request.Genre);

                if (IsInvalid())
                    return null;

                var result = _gameService.AddGame(game);

                if (result == null)
                    throw new NullReferenceException("The game could not be added.");

                return (AddGameResponse)result;
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Game game)
        {
            throw new NotImplementedException();
        }

        public GetAllGamesResponse GetAllGames()
        {
            try
            {
                List<Game> games = _gameService.GetAllGames();

                if (games == null || games.Count == 0)
                    throw new NullReferenceException("No game has been found on the database.");

                return (GetAllGamesResponse)games;
            }
            catch 
            {
                throw;
            }
        }

        public Game GetById(Game game)
        {
            throw new NotImplementedException();
        }

        public Game GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGamesByGenre(string genre)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGamesByProductor(string productor)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGamesByPublisher(string publisher)
        {
            throw new NotImplementedException();
        }

        public Game ModifyGame(Game game)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
