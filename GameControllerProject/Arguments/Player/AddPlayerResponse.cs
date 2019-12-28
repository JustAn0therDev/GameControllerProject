using System;
using GameControllerProject.Domain.Interfaces.Arguments;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class AddPlayerResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
