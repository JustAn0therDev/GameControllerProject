using GameControllerProject.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using GameControllerProject.Domain.Arguments.CustomTypes;

namespace GameControllerProject.Domain.Arguments.Game
{
    public class GetGameResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<GameWithPlatform> Games { get; set; } = new List<GameWithPlatform>();

        public static explicit operator GetGameResponse(List<GameWithPlatform> gamesWithPlatforms)
        {
            return new GetGameResponse
            {
                Success = true,
                Message = "Games successfully found for the provided value.",
                Games = gamesWithPlatforms
            };
        }
    }
}
