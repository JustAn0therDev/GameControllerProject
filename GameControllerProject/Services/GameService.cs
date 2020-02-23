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

        private readonly IGameRepository _gameRepository;

        #endregion

        #region Constructors

        public GameService(IGameRepository gameService)
        {
            _gameRepository = gameService;
        }

        #endregion

        #region Public Methods 

        public AddGameResponse AddGame(AddGameRequest request)
        {
            var game = new Game(request.Name, request.Productor, request.Publisher, request.Genre);

            if (IsInvalid())
                return null;

            var result = _gameRepository.AddGame(game);

            if (result == null)
                throw new NullReferenceException("The game could not be added.");

            return (AddGameResponse)result;
        }

        public DeleteGameResponse DeleteGame(DeleteGameRequest request)
        {

            _gameRepository.Delete(request.Id);

            return new DeleteGameResponse { Success = true, Message = "Game successfully deleted" };
        }

        public GetAllGamesResponse GetAllGames()
        {
            List<Game> games = _gameRepository.GetAllGames();

            if (games == null || games.Count == 0)
                throw new NullReferenceException("No game has been found on the database.");

            return (GetAllGamesResponse)games;
        }

        public Game GetById(Game game)
        {
            Game result = _gameRepository.GetById(game.Id);

            if (result == null)
                throw new NullReferenceException("Game not found");

            return result;
        }

        public Game GetByName(string name)
        {
            var game = _gameRepository.GetByName(name);

            if (game == null)
                throw new NullReferenceException("Game not found");

            return game;
        }

        public GetGameResponse GetGamesByGenre(string genre)
        {
            var games = _gameRepository.GetGamesByGenre(genre);

            if (games == null || games.Count == 0)
                throw new NullReferenceException("No games were found for the provided genre.");

            return (GetGameResponse)games;
        }

        public GetGameResponse GetGamesByProductor(string productor)
        {
            var games = _gameRepository.GetGamesByProductor(productor);

            if (games == null || games.Count == 0)
                throw new NullReferenceException("No games were found for the provided genre.");

            return (GetGameResponse)games;
        }

        public GetGameResponse GetGamesByPublisher(string publisher)
        {
            var games = _gameRepository.GetGamesByPublisher(publisher);

            if (games == null || games.Count == 0)
                throw new NullReferenceException("No games were found for the provided genre.");

            return (GetGameResponse)games;
        }

        public ModifyGameResponse ModifyGame(ModifyGameRequest request)
        {
            var game = new Game(
                request.Id
                , request.Name
                , request.Description
                , request.Productor
                , request.Publisher
                , request.Genre
                , request.Website
                );

            AddNotifications(game);

            if (IsInvalid())
                return null;

            game = _gameRepository.Update(game);

            if (game == null)
                throw new NullReferenceException("The provided game could not be updated.");

            return (ModifyGameResponse)game;
        }

        #endregion
    }
}
