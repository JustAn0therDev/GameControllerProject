﻿using GameControllerProject.Api.Controllers.Base;
using GameControllerProject.Domain.Arguments.Player;
using GameControllerProject.Domain.Interfaces.Services;
using GameControllerProject.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameControllerProject.API.Controllers
{
    [RoutePrefix("api/Player")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _playerService = playerService;
        }

        [HttpGet]
        [Route("GetAllPlayers")]
        public async Task<HttpResponseMessage> GetAllPlayers()
        {
            try
            {
                var response = _playerService.ListAllPlayers();
                return await ResponseAsync(response, _playerService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("AddPlayer")]
        public async Task<HttpResponseMessage> AddPlayer(AddPlayerRequest request)
        {
            try
            {
                var response = _playerService.AddPlayer(request);
                return await ResponseAsync(response, _playerService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("AuthenticatePlayer")]
        public async Task<HttpResponseMessage> AuthenticatePlayer(AuthenticatePlayerRequest request)
        {
            try
            {
                var response = _playerService.Authenticate(request);
                return await ResponseAsync(response, _playerService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("DeletePlayer")]
        public async Task<HttpResponseMessage> DeletePlayer(DeletePlayerRequest request) 
        {
            try
            {
                var response = _playerService.DeletePlayer(request);
                return await ResponseAsync(response, _playerService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("ModifyPlayer")]
        public async Task<HttpResponseMessage> ModifyPlayer(ModifyPlayerRequest request)
        {
            try
            {
                var response = _playerService.ModifyPlayer(request);
                return await ResponseAsync(response, _playerService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

    }
}