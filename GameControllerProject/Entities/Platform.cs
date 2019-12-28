using prmToolkit.NotificationPattern;
using System;

namespace GameControllerProject.Domain.Entities
{
    public class Platform : Notifiable
    {
        #region Public Members

        public Guid Id { get; set; }
        public string Name { get; set; }

        #endregion

        #region Constructors

        public Platform(string name)
        {
            Name = name;
            new AddNotifications<Platform>(this).IfNullOrEmpty(x => x.Name, "A platform must have a name.");
        }

        #endregion

    }
}
