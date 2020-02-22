using GameControllerProject.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameControllerProject.Domain.Arguments.Game
{
    public class ModifyGameResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Entities.Game Game { get; set; }

        public static explicit operator ModifyGameResponse(Entities.Game game)
        {
            return new ModifyGameResponse
            {
                Success = true,
                Message = "Game modified successfully",
                Game = game
            };
        }
    }
}
