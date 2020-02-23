using System;
using GameControllerProject.Domain.Entities.Base;

namespace GameControllerProject.Domain.Entities
{
    public class GamePlatform : EntityBase
    {
        #region Public Members

        public Guid GameId { get; set; }
        public Guid PlatformId { get; set; }

        #endregion

        #region Constructors 

        public GamePlatform()
        {

        }

        public GamePlatform(Guid gameId, Guid platformId)
        {
            GameId = gameId;
            PlatformId = platformId;
        }

        #endregion
    }
}
