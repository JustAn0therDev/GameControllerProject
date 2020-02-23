using GameControllerProject.Domain.Arguments.Platform;
using GameControllerProject.Domain.Interfaces.Repositories.Base;
using System;

namespace GameControllerProject.Domain.Interfaces.Repositories
{
    public interface IPlatformRepository : IRepositoryBase<Entities.Platform, Guid>
    {
        Entities.Platform AddPlatform(Entities.Platform entity);
    }
}
