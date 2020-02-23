using GameControllerProject.Api.Controllers.Base;
using GameControllerProject.Domain.Arguments.Game;
using GameControllerProject.Domain.Interfaces.Services;
using GameControllerProject.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameControllerProject.API.Controllers
{
    [RoutePrefix("api/Games")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [Route("GetGame")]
        public async Task<HttpResponseMessage> GetGame([FromUri]string type, string value)
        {
            try
            {
                GetGameResponse response = new GetGameResponse();
                switch (type.ToLower())
                {
                    case "genre":
                        response = _gameService.GetGamesByGenre(value);
                        break;
                    case "publisher":
                        response = _gameService.GetGamesByPublisher(value);
                        break;
                    case "productor":
                        response = _gameService.GetGamesByProductor(value);
                        break;
                    default:
                        throw new ArgumentException("Invalid type of value.");
                }
                return await ResponseAsync(response, _gameService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpGet]
        [Route("GetAllGames")]
        public async Task<HttpResponseMessage> GetAllGames()
        {
            try
            {
                var response = _gameService.GetAllGames();
                return await ResponseAsync(response, _gameService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("AddGame")]
        public async Task<HttpResponseMessage> AddGame(AddGameRequest request)
        {
            try
            {
                var response = _gameService.AddGame(request);
                return await ResponseAsync(response, _gameService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("ModifyGame")]
        public async Task<HttpResponseMessage> ModifyGame(ModifyGameRequest request)
        {
            try
            {
                var response = _gameService.ModifyGame(request);
                return await ResponseAsync(response, _gameService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("DeleteGame")]
        public async Task<HttpResponseMessage> DeleteGame(DeleteGameRequest request)
        {
            try
            {
                var response = _gameService.DeleteGame(request);
                return await ResponseAsync(response, _gameService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}