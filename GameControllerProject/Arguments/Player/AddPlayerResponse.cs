using System;
using GameControllerProject.Domain.Interfaces.Arguments;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class AddPlayerResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static explicit operator AddPlayerResponse(Entities.Player player)
        {
            return new AddPlayerResponse()
            {
                Id = Guid.NewGuid(),
                Message = "Player added successfully"
            };
        }
    }
}
