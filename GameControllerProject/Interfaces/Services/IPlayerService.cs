using GameControllerProject.Domain.Arguments.Player;
using GameControllerProject.Domain.Entities;
using System.Collections.Generic;

namespace GameControllerProject.Domain.Interfaces.Services
{
    public interface IPlayerService
    {
        AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest authenticatePlayerRequest);
        AddPlayerResponse AddPlayer(AddPlayerRequest addPlayerRequest);
        ModifyPlayerResponse ModifyPlayer(ModifyPlayerRequest addPlayerRequest);
        List<ListAllPlayersResponse> ListAllPlayers();
    }
}
