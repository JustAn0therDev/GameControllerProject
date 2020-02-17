using prmToolkit.NotificationPattern;

namespace GameControllerProject.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name()
        {

        }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            new AddNotifications<Name>(this).IfNullOrInvalidLength(x => x.FirstName, 3, 50, "A first name must be provided or have a length between 3 and 50 characters.")
                .IfNullOrInvalidLength(x => x.LastName, 3, 50, "A last name must be provided or have a length between 3 and 50 characters.");
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
