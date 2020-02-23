using GameControllerProject.Domain.Arguments.Platform;
using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameControllerProject.Domain.Services
{
    public class PlatformService : Notifiable, IPlatformService
    {
        #region Private Members

        private readonly IPlatformRepository _platformRepository;

        #endregion

        #region Constructors 

        public PlatformService(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        #endregion

        public GetAllPlatformsResponse GetAllPlatforms()
        {
            List<Platform> platforms = _platformRepository.GetAll().ToList();

            if (platforms == null || platforms.Count == 0)
                throw new NullReferenceException("Nothing was found in the platform repository");

            return (GetAllPlatformsResponse)platforms;
        }


        public AddPlatformResponse AddPlatForm(AddPlatformRequest addPlatformRequest)
        {
            Platform platform = new Platform(addPlatformRequest.PlatformName);

            AddNotifications(platform);

            if (IsInvalid())
                return null;

            var result = _platformRepository.AddPlatform(platform);


            if (result == null)
                throw new NullReferenceException("Platform could not be added");

            return (AddPlatformResponse)result;
        }
    }
}
