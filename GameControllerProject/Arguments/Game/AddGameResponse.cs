using GameControllerProject.Domain.Interfaces.Arguments;
using GameControllerProject.Domain.Arguments.CustomTypes;
using System;
using System.Collections.Generic;

namespace GameControllerProject.Domain.Arguments.Game
{
    public class AddGameResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<GameWithPlatform> GamesWithPlatforms { get; set; }
    }
}
