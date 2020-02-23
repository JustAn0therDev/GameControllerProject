using System;
using GameControllerProject.Domain.Interfaces.Arguments;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class ModifyPlayerResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Guid Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public static explicit operator ModifyPlayerResponse(Entities.Player player)
        {
            return new ModifyPlayerResponse()
            {
                Success = true,
                Message = "Player modified successfully."
                Id = player.Id,
                FirstName = player.Name.FirstName,
                LastName = player.Name.LastName,
                Email = player.Email.Address,
            };
        }
    }
}
