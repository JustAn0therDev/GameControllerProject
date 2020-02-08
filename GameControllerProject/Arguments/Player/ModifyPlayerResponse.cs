using System;
using GameControllerProject.Domain.Interfaces.Arguments;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class ModifyPlayerResponse : IResponse
    {
        public Guid Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

        public static explicit operator ModifyPlayerResponse(Entities.Player player)
        {
            return new ModifyPlayerResponse()
            {
                Id = player.Id,
                FirstName = player.Name.FirstName,
                LastName = player.Name.LastName,
                Email = player.Email.Address,
                Message = "Player modified successfully."
            };
        }
    }
}
