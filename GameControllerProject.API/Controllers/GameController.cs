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

    }
}