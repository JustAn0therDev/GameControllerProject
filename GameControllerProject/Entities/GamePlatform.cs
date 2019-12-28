using System;

namespace GameControllerProject.Domain.Entities
{
    public class GamePlatform
    {
        #region Public Members

        public Guid Id { get; set; }
        public Game Game { get; set; }
        public Platform Platform { get; set; }
        public DateTime LaunchDate { get; set; }

        #endregion 
    }
}
