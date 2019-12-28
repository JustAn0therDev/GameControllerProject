using GameControllerProject.Domain.Arguments.Platform;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameControllerProject.Domain.Interfaces.Services
{
    public interface IPlatformService
    {
        AddPlatformResponse AddPlatForm(AddPlatformRequest addPlatformRequest);
    }
}
