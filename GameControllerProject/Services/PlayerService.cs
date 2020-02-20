using GameControllerProject.Domain.Arguments.Base;
using GameControllerProject.Domain.Arguments.Player;
using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Enums;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Domain.Interfaces.Services;
using GameControllerProject.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameControllerProject.Domain.Services
{
    public class PlayerService : Notifiable, IPlayerService
    {
        #region Private Members

        private readonly IPlayerRepository _playerRepository;

        #endregion

        #region Constructors

        //Injeção de Dependência
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        #endregion

        #region Public Methods

        public AddPlayerResponse AddPlayer(AddPlayerRequest addPlayerRequest)
        {
            AddPlayerResponse response = new AddPlayerResponse();
            Name name = new Name(addPlayerRequest.FirstName, addPlayerRequest.LastName);
            Email email = new Email(addPlayerRequest.Email);
            string password = addPlayerRequest.Password;

            Player player = new Player(name, email, password);

            AddNotifications(name, email);

            if (IsInvalid())
                return null;

            player = _playerRepository.Add(player);

            if (player == null) return null;

            response.Message = "Player added successfully";
            return (AddPlayerResponse)player;
        }

        public AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest authenticatePlayerRequest)
        {
            Email email = new Email(authenticatePlayerRequest.Email);
            string password = authenticatePlayerRequest.Password;

            Player player = new Player(email, password);

            AddNotifications(player, email);

            if (IsInvalid())
                return null;

            player = _playerRepository.GetByEmailAndEncryptedPassword(player.Email.Address, player.Password);

            if (player == null)
            {
                return new AuthenticatePlayerResponse
                {
                    Email = authenticatePlayerRequest.Email,
                    FirstName = string.Empty,
                    Message = "Incorrect e-mail and/or password."
                };
            }

            return (AuthenticatePlayerResponse)player;
        }

        public ModifyPlayerResponse ModifyPlayer(ModifyPlayerRequest modifyPlayerRequest)
        {
            if (modifyPlayerRequest == null)
            {
                AddNotification("ModifyPlayerRequest", "Request can't be responded without parameters.");
                return null;
            }

            var player = _playerRepository.GetById(modifyPlayerRequest.Id);

            if (player == null)
            {
                AddNotification("Id", "Player not Found.");
                return null;
            }

            var name = new Name(modifyPlayerRequest.FirstName, modifyPlayerRequest.LastName);
            var email = new Email(modifyPlayerRequest.Email);

            player.ModifyPlayer(name, email, (PlayerStatus)modifyPlayerRequest.Status);

            AddNotifications(player);

            if (IsInvalid())
                return null;

            _playerRepository.Update(player);

            return (ModifyPlayerResponse)player;
        }

        public ListAllPlayersResponse ListAllPlayers()
        {
            List<Player> list = _playerRepository.GetAll().ToList();

            return new ListAllPlayersResponse
            {
                Message = "Players retrived successfully",
                Players = list
            };
        }

        public ResponseBase DeletePlayer(DeletePlayerRequest deletePlayerRequest)
        {
            var player = _playerRepository.GetByEmail(deletePlayerRequest.Email);

            if (player == null)
                throw new NullReferenceException("Player not found.");
            else
                AddNotifications(player.Name, player.Email, player);

            if (IsInvalid())
                return null;

            _playerRepository.Delete(player);

            return (ResponseBase)player;
        }

        #endregion
    }
}
