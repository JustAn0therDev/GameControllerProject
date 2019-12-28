using GameControllerProject.Domain.Interfaces.Arguments;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class AuthenticatePlayerRequest : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
