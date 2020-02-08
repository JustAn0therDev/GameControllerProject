using GameControllerProject.Domain.Arguments.Player;
using GameControllerProject.Domain.Entities;
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
            Name name = new Name(addPlayerRequest.Name.FirstName, addPlayerRequest.Name.LastName);
            Email email = new Email(addPlayerRequest.Email);
            string password = addPlayerRequest.Password;

            Player player = new Player(name, email, password);

            if (IsInvalid())
                return null;

            player = _playerRepository.AddPlayer(player);

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

            if (_playerRepository != null)
                player = _playerRepository.Authenticate(email.Address, password);

            return (AuthenticatePlayerResponse)player;
        }

        public ModifyPlayerResponse ModifyPlayer(ModifyPlayerRequest modifyPlayerRequest)
        {
            if (modifyPlayerRequest == null)
            {
                AddNotification("ModifyPlayerRequest", "Request can't be responded without parameters.");
                return null;
            }

            var player = _playerRepository.GetPlayerById(modifyPlayerRequest.Id);

            if (player == null)
            {
                AddNotification("Id", "Player not Found.");
                return null;
            }

            var name = new Name(modifyPlayerRequest.FirstName, modifyPlayerRequest.LastName);
            var email = new Email(modifyPlayerRequest.Email);

            player.ModifyPlayer(name, email);

            AddNotifications(player);

            if (IsInvalid())
                return null;

            _playerRepository.ModifyPlayer(player);

            return (ModifyPlayerResponse)player;
        }

        public List<ListAllPlayersResponse> ListAllPlayers()
        {
            return _playerRepository.GetAllPlayers().Select(s => (ListAllPlayersResponse)s).ToList();
        }

        #endregion
    }
}
