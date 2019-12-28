using GameControllerProject.Domain.Arguments.Player;
using GameControllerProject.Domain.Entities;

namespace GameControllerProject.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        AuthenticatePlayerResponse Authenticate(string email, string password);
        AddPlayerResponse AddPlayer(Player playerToBeAdded);
    }
}
