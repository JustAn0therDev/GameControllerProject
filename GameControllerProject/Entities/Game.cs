using GameControllerProject.Domain.Entities.Base;
using prmToolkit.NotificationPattern;
using System;

namespace GameControllerProject.Domain.Entities
{
    public class Game : EntityBase
    {
        #region Public Members

            public string Name { get; set; }
            public string Description { get; set; }
            public string Productor { get; set; }
            public string Publisher { get; set; }
            public string Genre { get; set; }
            public string Website { get; set; }

        #endregion

        #region Constructors

        public Game()
        {

        }

        public Game(string name, string productor, string publisher, string genre)
        {
            Name = name;
            Productor = productor;
            Publisher = publisher;
            Genre = genre;

            new AddNotifications<Game>(this).IfNullOrEmpty(x => x.Name, "A game must at least have a name.");
        }

        public Game(string name, string description, string productor, string publisher, string genre, string website)
        {
            Name = name;
            Description = description;
            Productor = productor;
            Publisher = publisher;
            Genre = genre;
            Website = website;

            new AddNotifications<Game>(this).IfNullOrEmpty(x => x.Name, "A game must at least have a name.");
        }

        public Game(Guid id, string name, string description, string productor, string publisher, string genre, string website)
        {
            Id = id;
            Name = name;
            Description = description;
            Productor = productor;
            Publisher = publisher;
            Genre = genre;
            Website = website;

            new AddNotifications<Game>(this).IfNull(x => x.Id, "Game not found.");
            new AddNotifications<Game>(this).IfNullOrEmpty(x => x.Name, "A game must at least have a name.");
        }


        #endregion
    }
}
