using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Infra.Persistence.Repositories.Base;
using System;
using System.Linq;

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

        public IQueryable<Platform> GetAll()
        {
            return _context.Platforms.Select(s => s);
        }

        #endregion
    }
}
