using System;

namespace GameControllerProject.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Productor { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Website { get; set; }
    }
}
