using System;
using System.Collections.Generic;

using GameControllerProject.Domain.Interfaces.Arguments;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class ListAllPlayersResponse : IResponse
    {
        public List<Entities.Player> Players { get; set; } = new List<Entities.Player>();
        public string Message { get; set; }

        public static explicit operator ListAllPlayersResponse(List<Entities.Player> players)
        {
            return new ListAllPlayersResponse()
            {
                Players = players,
                Message = "Player found successfully"
            };
        }
    }
}
