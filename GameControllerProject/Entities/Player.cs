using GameControllerProject.Domain.Entities.Base;
using GameControllerProject.Domain.Enums;
using GameControllerProject.Domain.Extensions;
using GameControllerProject.Domain.ValueObjects;
using prmToolkit.NotificationPattern;

namespace GameControllerProject.Domain.Entities
{
    public class Player : EntityBase
    {
        #region Public Members

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public PlayerStatus Status { get; private set; }

        #endregion

        #region Constructors 

        public Player()
        {

        }

        public Player(Email email, string password) : base()
        {
            Email = email;
            Password = password;
            Status = PlayerStatus.Pending;

            new AddNotifications<Player>(this)
                .IfNullOrInvalidLength(x => x.Password, 6, 30, "A password must be provided and have between 6 and 30 characters.");

            if (IsValid())
                Password = password.ConvertToMD5();
        }

        public Player(Name name, Email email, string password) : base()
        {
            Name = name;
            Email = email;
            Password = password;
            Status = PlayerStatus.Pending;

            new AddNotifications<Player>(this)
                .IfNullOrInvalidLength(x => x.Password, 6, 30, "A password must be provided and have between 6 and 30 characters.");

            if (IsValid())
                Password = password.ConvertToMD5();

            AddNotifications(Name, Email);
        }

        public Player(Name name, Email email, string password, int status) : base()
        {
            Name = name;
            Email = email;
            Password = password;
            Status = (PlayerStatus)status;

            new AddNotifications<Player>(this)
                .IfNullOrInvalidLength(x => x.Password, 6, 30, "A password must be provided and have between 6 and 30 characters.");

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

        public void ModifyPlayer(Name name, Email email, PlayerStatus status)
        {
            Name = name;
            Email = email;
            Status = status;

            new AddNotifications<Player>(this)
                .IfFalse(Status == PlayerStatus.Active, "The player needs to be active to be modified.");

            AddNotifications(Name, Email);
        }

        public void AuthenticatePlayer(Email email, string password)
        {
            Email = email;
            Password = password;
            Status = PlayerStatus.Pending;

            new AddNotifications<Player>(this)
                .IfNullOrInvalidLength(x => x.Password, 6, 30, "A password must be provided and have between 6 and 30 characters.");

            if (IsValid())
                Password = password.ConvertToMD5();
        }

        #endregion
    }
}
