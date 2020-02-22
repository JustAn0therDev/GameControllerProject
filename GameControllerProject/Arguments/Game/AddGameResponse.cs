using GameControllerProject.Domain.Interfaces.Arguments;
using GameControllerProject.Domain.Entities;
using System;

namespace GameControllerProject.Domain.Arguments.Game
{
    public class AddGameResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Entities.Game Game { get; set; }

        public static explicit operator AddGameResponse(Entities.Game game)
        {
            return new AddGameResponse
            {
                Success = true,
                Message = "Game added successfully",
                Game = game
            };
        }
    }
}
