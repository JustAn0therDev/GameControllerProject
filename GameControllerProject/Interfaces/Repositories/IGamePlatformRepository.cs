using GameControllerProject.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;

namespace GameControllerProject.Domain.Interfaces.Repositories
{
    public interface IGamePlatformRepository : IRepositoryBase<Entities.GamePlatform, Guid>
    {
        Entities.GamePlatform AddGamePlatform(Guid gameId, Guid platformId);
        List<Entities.Platform> GetAllPlatforms(Guid gameId);
    }
}
