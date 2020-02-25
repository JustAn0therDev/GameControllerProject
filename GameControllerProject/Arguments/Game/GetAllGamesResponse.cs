using GameControllerProject.Domain.Arguments.CustomTypes;
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
        public List<GameWithPlatform> GamesWithPlatforms { get; set; } = new List<GameWithPlatform>();

        public static explicit operator GetAllGamesResponse(List<GameWithPlatform> gamesWithPlatforms)
        {
            return new GetAllGamesResponse
            {
                Success = true,
                Message = "All games returned successfully",
                GamesWithPlatforms = gamesWithPlatforms
            };
        }
    }
}
