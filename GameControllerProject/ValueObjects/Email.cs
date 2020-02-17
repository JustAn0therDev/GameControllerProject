using prmToolkit.NotificationPattern;

namespace GameControllerProject.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        #region Public Members

        public string Address { get; private set; }

        #endregion

        #region Constructors

        public Email()
        {

        }

        public Email (string address)
        {
            Address = address;

            new AddNotifications<Email>(this).IfNotEmail(x => x.Address, "The informed address has to be valid");
        }

        #endregion
    }
}
