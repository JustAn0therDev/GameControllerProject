using System.Linq;
using System.Collections.Generic;

using GameControllerProject.Domain.Interfaces.Arguments;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class ListAllPlayersResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Entities.Player> Players { get; set; }

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
