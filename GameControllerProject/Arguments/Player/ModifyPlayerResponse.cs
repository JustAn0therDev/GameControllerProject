using GameControllerProject.Domain.Interfaces.Arguments;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class ModifyPlayerResponse : IResponse
    {
        public GameControllerProject.Domain.Entities.Player Player { get; set; }
        public string Message { get; set; }

        public static explicit operator ModifyPlayerResponse(Entities.Player player)
        {
            return new ModifyPlayerResponse()
            {
                Player = player,
                Message = "Player modified successfully"
            };
        }
    }
}
