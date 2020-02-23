using GameControllerProject.Domain.Interfaces.Arguments;
using System;

namespace GameControllerProject.Domain.Arguments.Game
{
    public class DeleteGameRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}
