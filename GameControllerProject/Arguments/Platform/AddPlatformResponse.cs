using System;
using System.Collections.Generic;
using System.Text;

using GameControllerProject.Domain.Entities;

namespace GameControllerProject.Domain.Arguments.Platform
{
    public class AddPlatformResponse
    {
        public GamePlatform Platform { get; set; }
        public string Message { get; set; }
    }
}
