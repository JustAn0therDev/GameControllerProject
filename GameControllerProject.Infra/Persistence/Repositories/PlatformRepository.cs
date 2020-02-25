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

        public new IQueryable<Platform> GetAll()
        {
            return _context.Platforms.Select(s => s);
        }

        public void Delete(Guid id)
        {
            var result = _context.Platforms.Find(id);
            _context.Platforms.Remove(result);
            _context.SaveChanges();
        }

        public new Platform Update(Platform entity)
        {
            var result = _context.Platforms.Find(entity.Id);
            if (result == null)
                throw new NullReferenceException("The requested platform for update was not found in the repository.");

            result.Name = entity.Name;
            _context.SaveChanges();
            return result;
        }

        #endregion
    }
}
