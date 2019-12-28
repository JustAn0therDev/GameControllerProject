using GameControllerProject.Domain.Arguments.Platform;
using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Services;

namespace GameControllerProject.Domain.Services
{
    class PlatformService : IPlatformService
    {
        #region Private Members
        private readonly IPlatformService _platformService;
        #endregion

        #region Constructors 

        public PlatformService(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        #endregion

        public AddPlatformResponse AddPlatForm(AddPlatformRequest addPlatformRequest)
        {
            Platform platform = new Platform(addPlatformRequest.PlatformName);

            AddPlatformResponse response = _platformService.AddPlatForm(addPlatformRequest);

            return response;
        }
    }
}
