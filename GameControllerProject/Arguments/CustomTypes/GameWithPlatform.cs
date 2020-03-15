using System.Collections.Generic;

namespace GameControllerProject.Domain.Arguments.CustomTypes
{
    public class GameWithPlatform
    {
        public Entities.Game Game { get; set; }
        public List<Entities.Platform> Platforms { get; set; } = new List<Entities.Platform>();
        public GameWithPlatform(Entities.Game game, List<Entities.Platform> platforms)
        {
            Game = game;
            Platforms = platforms;
        }
    }
}
