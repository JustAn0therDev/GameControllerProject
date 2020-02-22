using GameControllerProject.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;

namespace GameControllerProject.Domain.Arguments.Game
{
    public class GetGameResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Entities.Game> Games { get; set; } = new List<Entities.Game>();

        public static explicit operator GetGameResponse(List<Entities.Game> games)
        {
            return new GetGameResponse
            {
                Success = true,
                Message = "Games successfully found for the provided value.",
                Games = games
            };
        }
    }
}
