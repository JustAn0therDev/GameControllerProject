using GameControllerProject.Domain.Arguments.Platform;
using GameControllerProject.Domain.Interfaces.Services.Base;

namespace GameControllerProject.Domain.Interfaces.Services
{
    public interface IPlatformService : IServiceBase
    {
        AddPlatformResponse AddPlatForm(AddPlatformRequest addPlatformRequest);
    }
}
