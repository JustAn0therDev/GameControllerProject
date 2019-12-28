using GameControllerProject.Domain.Arguments.Player;

namespace GameControllerProject.Domain.Interfaces.Services
{
    public interface IPlayerService
    {
        AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest authenticatePlayerRequest);
        AddPlayerResponse AddPlayer(AddPlayerRequest addPlayerRequest);
    }
}
