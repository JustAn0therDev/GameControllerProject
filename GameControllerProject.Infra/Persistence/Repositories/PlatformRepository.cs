using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Infra.Persistence.Repositories.Base;
using System;

namespace GameControllerProject.Infra.Persistence.Repositories
{
    public class PlatformRepository : RepositoryBase<Platform, Guid>, IPlatformRepository
    {
        #region Private Members

        private new readonly GameControllerProjectContext _context;

        #endregion

        #region Constructors

        public PlatformRepository(GameControllerProjectContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        public Platform AddPlatform(Platform entity)
        {
            return _context.Platforms.Add(entity);
        }

        #endregion
    }
}
