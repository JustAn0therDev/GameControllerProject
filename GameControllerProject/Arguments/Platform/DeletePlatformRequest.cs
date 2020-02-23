using GameControllerProject.Domain.Interfaces.Arguments;
using System;

namespace GameControllerProject.Domain.Arguments.Platform
{
    public class DeletePlatformRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}
