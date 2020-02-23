using GameControllerProject.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameControllerProject.Domain.Arguments.Platform
{
    public class ModifyPlatformResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Entities.Platform Platform { get; set; }

        public static explicit operator ModifyPlatformResponse(Entities.Platform platform)
        {
            return new ModifyPlatformResponse
            {
                Success = true,
                Message = "Platform modified successfully",
                Platform = platform
            };
        }
    }
}
