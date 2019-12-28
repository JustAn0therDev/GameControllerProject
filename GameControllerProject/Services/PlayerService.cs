using GameControllerProject.Domain.Arguments.Player;
using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Domain.Interfaces.Services;
using GameControllerProject.Domain.ValueObjects;
using prmToolkit.NotificationPattern;

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
            Name name = new Name(addPlayerRequest.Name.FirstName, addPlayerRequest.Name.LastName);
            Email email = new Email(addPlayerRequest.Email);
            string password = addPlayerRequest.Password;

            Player player = new Player(name, email, password);

            if (IsInvalid())
                return null;

            AddPlayerResponse response = _playerRepository.AddPlayer(player);
            response.Message = "Player added successfully";
            return response;
        }

        public AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest authenticatePlayerRequest)
        {
            AuthenticatePlayerResponse response = new AuthenticatePlayerResponse();
            Email email = new Email(authenticatePlayerRequest.Email);
            string password = authenticatePlayerRequest.Password;

            Player player = new Player(email, password);

            AddNotifications(player, email);

            if (IsInvalid())
                return null;

            if (_playerRepository != null)
                response = _playerRepository.Authenticate(email.Address, password);

            response.Message = "The player was successfully authenticated.";

            return response;
        }

        #endregion
    }
}
