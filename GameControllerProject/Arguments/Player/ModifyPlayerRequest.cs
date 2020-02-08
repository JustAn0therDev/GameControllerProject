using GameControllerProject.Domain.Interfaces.Arguments;
using System;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class ModifyPlayerRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
