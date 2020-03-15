namespace GameControllerProject.Domain.Arguments.Base
{
    public class ResponseBase
    {
        public string Message { get; set; }

        public static explicit operator ResponseBase(Entities.Player player)
        {
            return new ResponseBase
            {
                Message = player != null ? "Player successfully deleted." : "The requested player could not be found."
            };
        }
    }
}
