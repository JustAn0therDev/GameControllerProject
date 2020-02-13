using System;
using GameControllerProject.Domain.Arguments.Player;
using GameControllerProject.Domain.Arguments.Base;

namespace GameControllerProject.Domain.Interfaces.Services
{
    public interface IPlayerService
    {
        AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest authenticatePlayerRequest);
        AddPlayerResponse AddPlayer(AddPlayerRequest addPlayerRequest);
        ModifyPlayerResponse ModifyPlayer(ModifyPlayerRequest addPlayerRequest);
        ListAllPlayersResponse ListAllPlayers();
        ResponseBase DeletePlayer(Guid Id);
    }
}
