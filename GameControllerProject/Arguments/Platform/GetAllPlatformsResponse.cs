using GameControllerProject.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;

namespace GameControllerProject.Domain.Arguments.Platform
{
    public class GetAllPlatformsResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Entities.Platform> Platforms { get; set; }

        public static explicit operator GetAllPlatformsResponse(List<Entities.Platform> platforms)
        {
            return new GetAllPlatformsResponse
            {
                Success = true,
                Message = "All platforms returned successfully",
                Platforms = platforms
            };
        }
    }
}
