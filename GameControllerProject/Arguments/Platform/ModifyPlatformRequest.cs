using GameControllerProject.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameControllerProject.Domain.Arguments.Platform
{
    public class ModifyPlatformRequest : IRequest
    {
        public Guid Id { get; set; }
        public string PlatformName { get; set; }
    }
}
