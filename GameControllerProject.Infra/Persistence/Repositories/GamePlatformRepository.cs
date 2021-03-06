﻿using GameControllerProject.Domain.Entities;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Infra.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameControllerProject.Infra.Persistence.Repositories
{
    public class GamePlatformRepository : RepositoryBase<GamePlatform, Guid>, IGamePlatformRepository
    {
        #region Private Members

        private new readonly GameControllerProjectContext _context;

        #endregion

        #region Constructors

        public GamePlatformRepository(GameControllerProjectContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        public GamePlatform AddGamePlatform(Guid gameId, Guid platformId)
        {
            return _context.GamePlatforms.Add(new GamePlatform { GameId = gameId, PlatformId = platformId });
        }

        public List<Platform> GetAllPlatforms(Guid gameId)
        {
            var gamePlatformRelations = _context.GamePlatforms.Where(w => w.GameId == gameId).ToList();
            var platforms = new List<Platform>();

            if (gamePlatformRelations != null && gamePlatformRelations.Count > 0)
                foreach (var item in gamePlatformRelations)
                {
                    platforms.Add(_context.Platforms.Find(item.PlatformId));
                }

            return platforms;
        }

        public void UpdateGamePlatformsList(Guid gameId, List<Guid> platformIds)
        {
            List<Platform> platforms = new List<Platform>();

            var currentData = GetAllPlatforms(gameId).AsQueryable();

            if (platformIds != null && platformIds.Count > 0)
            {
                foreach (var platformId in platformIds)
                {
                    platforms.Add(_context.Platforms.Where(w => w.Id == platformId).FirstOrDefault());
                }

                List<Platform> newPlatforms = platforms.Except(currentData).ToList();

                List<Platform> platformsToBeDeleted = currentData.Except(platforms).ToList();

                if (platformsToBeDeleted != null && platformsToBeDeleted.Count > 0)
                {
                    foreach (var toDel in platformsToBeDeleted)
                    {
                        var platformToDelete = _context.GamePlatforms.Where(w => w.GameId == gameId && w.PlatformId == toDel.Id).FirstOrDefault();
                        _context.GamePlatforms.Remove(platformToDelete);
                        _context.SaveChanges();
                    }
                }

                if (newPlatforms != null && newPlatforms.Count > 0)
                {
                    foreach (var platform in newPlatforms)
                    {
                        AddGamePlatform(gameId, platform.Id);
                    }
                }
            }
        }

        #endregion
    }
}
