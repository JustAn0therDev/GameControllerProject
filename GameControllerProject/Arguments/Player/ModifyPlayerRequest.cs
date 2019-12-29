using GameControllerProject.Domain.Interfaces.Arguments;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class ModifyPlayerRequest : IRequest
    {
        public GameControllerProject.Domain.Entities.Player Player { get; set; }
    }
}
