using GameControllerProject.Domain.Interfaces.Arguments;
using System;

namespace GameControllerProject.Domain.Arguments.Platform
{
    public class AddPlatformResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Entities.Platform Platform { get; set; }

        public static explicit operator AddPlatformResponse(Entities.Platform platform)
        {
            return new AddPlatformResponse
            {
                Success = true,
                Message = "Platform added successfully",
                Platform = platform
            };
        }
    }
}
