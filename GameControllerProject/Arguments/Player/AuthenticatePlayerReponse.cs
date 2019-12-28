using GameControllerProject.Domain.Interfaces.Arguments;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class AuthenticatePlayerResponse : IResponse
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
