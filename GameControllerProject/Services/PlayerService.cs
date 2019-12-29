using GameControllerProject.Domain.Arguments.Player;
using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Domain.Interfaces.Services;
using GameControllerProject.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
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
            Name name = new Name(modifyPlayerRequest.Player.Name.FirstName, modifyPlayerRequest.Player.Name.LastName);
            Email email = new Email(modifyPlayerRequest.Player.Email.Address);

            //get by id no banco para saber se o jogador a ser modificado já existe.
            Player player = new Player(email, "12345");

            //comparar os dados que foram encontrados no banco com os dados que foram recebidos.
            return (ModifyPlayerResponse)player;
        }

        public List<ListAllPlayersResponse> ListAllPlayers()
        {
            return _playerRepository.GetAllPlayers().Select(s => (ListAllPlayersResponse)s).ToList();
        }

        #endregion
    }
}
