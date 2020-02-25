using GameControllerProject.Domain.Interfaces.Arguments;
using GameControllerProject.Domain.Arguments.CustomTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameControllerProject.Domain.Arguments.Game
{
    public class ModifyGameResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public GameWithPlatform Game { get; set; }

        public static explicit operator ModifyGameResponse(GameWithPlatform gameWithPlatform)
        {
            return new ModifyGameResponse
            {
                Success = true,
                Message = "Game modified successfully",
                Game = gameWithPlatform
            };
        }
    }
}
