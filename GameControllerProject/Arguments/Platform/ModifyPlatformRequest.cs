using GameControllerProject.Domain.Interfaces.Arguments;
using System;

namespace GameControllerProject.Domain.Arguments.Platform
{
    public class ModifyPlatformRequest : IRequest
    {
        public Guid Id { get; set; }
        public string PlatformName { get; set; }
    }
}
