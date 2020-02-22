using GameControllerProject.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameControllerProject.Domain.Arguments.Game
{
    public class GetAllGamesResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Entities.Game> Games { get; set; }

        public static explicit operator GetAllGamesResponse(List<Entities.Game> games)
        {
            return new GetAllGamesResponse
            {
                Success = true,
                Message = "All games returned successfully",
                Games = games
            };
        }
    }
}
