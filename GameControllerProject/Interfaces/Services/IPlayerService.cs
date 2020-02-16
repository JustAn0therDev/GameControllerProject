using System;
using GameControllerProject.Domain.Arguments.Player;
using GameControllerProject.Domain.Arguments.Base;
using GameControllerProject.Domain.Interfaces.Services.Base;

namespace GameControllerProject.Domain.Interfaces.Services
{
    public interface IPlayerService : IServiceBase
    {
        AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest authenticatePlayerRequest);
        AddPlayerResponse AddPlayer(AddPlayerRequest addPlayerRequest);
        ModifyPlayerResponse ModifyPlayer(ModifyPlayerRequest addPlayerRequest);
        ListAllPlayersResponse ListAllPlayers();
        ResponseBase DeletePlayer(DeletePlayerRequest deletePlayerRequest);
    }
}
