using GameControllerProject.Domain.Arguments.Game;
using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Domain.Interfaces.Services;
using GameControllerProject.Domain.Arguments.CustomTypes;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameControllerProject.Domain.Services
{
    public class GameService : Notifiable, IGameService
    {
        #region Private Members

        private readonly IGameRepository _gameRepository;
        private readonly IGamePlatformRepository _gamePlatformRepository;

        #endregion

        #region Constructors

        public GameService(IGameRepository gameRepository, IGamePlatformRepository gamePlatformRepository)
        {
            _gameRepository = gameRepository;
            _gamePlatformRepository = gamePlatformRepository;
        }

        #endregion

        #region Public Methods 

        public AddGameResponse AddGame(AddGameRequest request)
        {
            var resp = new AddGameResponse();
            var game = new Game(request.Name, request.Productor, request.Publisher, request.Genre);

            if (IsInvalid())
                return null;

            var result = _gameRepository.AddGame(game);

            if (result == null)
                throw new NullReferenceException("The game could not be added.");

            foreach (var platformId in request.Platforms)
            {
                _gamePlatformRepository.Add(new GamePlatform { GameId = result.Id, PlatformId = platformId });
            }

            resp.GamesWithPlatforms.Add(new GameWithPlatform(result, _gamePlatformRepository.GetAllPlatforms(result.Id)));

            resp.Success = true;
            resp.Message = "Game added successfully";
            return resp;
        }

        public DeleteGameResponse DeleteGame(DeleteGameRequest request)
        {

            _gameRepository.Delete(request.Id);

            return new DeleteGameResponse { Success = true, Message = "Game successfully deleted" };
        }

        public GetAllGamesResponse GetAllGames()
        {
            var resp = new GetAllGamesResponse();
            List<Game> games = _gameRepository.GetAllGames();

            if (games == null || games.Count == 0)
                throw new NullReferenceException("No game has been found on the database.");

            foreach (var game in games)
            {
                List<Platform> platforms = new List<Platform>();
                platforms.AddRange(_gamePlatformRepository.GetAllPlatforms(game.Id).ToList());

                var gameWithPlatform = new GameWithPlatform(game, platforms);

                resp.GamesWithPlatforms.Add(gameWithPlatform);
            }

            resp.Success = true;
            resp.Message = "Games with platforms retrieved successfully";
            return resp;
        }

        public GameWithPlatform GetById(Game game)
        {
            Game foundGame = _gameRepository.GetById(game.Id);

            if (foundGame == null)
                throw new NullReferenceException("Game not found");

            GameWithPlatform resp = new GameWithPlatform(
                foundGame
                , _gamePlatformRepository.GetAllPlatforms(foundGame.Id)
                );

            return resp;
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
