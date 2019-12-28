using System;

namespace GameControllerProject.Domain.Entities
{
    public class MyGame
    {
        public Guid Id { get; set; }
        public GamePlatform GamePlatForm { get; set; }
        public DateTime MarkedAsWishedDate { get; set; }
        public bool IsWanted { get; set; }
        public bool IsExchangeable { get; set; }
        public bool IsSellable { get; set; }
    }
}
