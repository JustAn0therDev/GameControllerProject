using System;
using System.Collections.Generic;

using GameControllerProject.Domain.Interfaces.Arguments;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class ListAllPlayersResponse : IResponse
    {
        public GameControllerProject.Domain.Entities.Player Player { get; set; }
        public string Message { get; set; }

        public static explicit operator ListAllPlayersResponse(Entities.Player player)
        {
            return new ListAllPlayersResponse()
            {
                Player = player,
                Message = "Player found successfully"
            };
        }
    }
}
