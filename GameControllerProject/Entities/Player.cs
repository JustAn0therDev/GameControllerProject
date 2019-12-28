using GameControllerProject.Domain.Enums;
using GameControllerProject.Domain.Extensions;
using GameControllerProject.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using System;

namespace GameControllerProject.Domain.Entities
{
    public class Player : Notifiable
    {
        #region Public Members

        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public PlayerStatus Status { get; private set; }

        #endregion

        #region Constructors 

        public Player(Email email, string password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
            Status = PlayerStatus.Pending;

            new AddNotifications<Player>(this).IfNullOrInvalidLength(x => x.Password, 6, 30, "A password must be provided and have between 6 and 30 characters.");

            if (IsValid())
                Password = password.ConvertToMD5();
        }

        public Player(Name name, Email email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            Status = PlayerStatus.Pending;

            new AddNotifications<Player>(this).IfNullOrInvalidLength(x => x.Password, 6, 30, "A password must be provided and have between 6 and 30 characters.");

            if (IsValid())
                Password = password.ConvertToMD5();

            AddNotifications(Name, Email);
        }

        #endregion

        #region Public Methods 

        public void ModifyPlayerStatus(int status)
        {
            Status = (PlayerStatus)status;
        }

        #endregion
    }
}
