namespace GameControllerProject.Domain.Interfaces.Arguments
{
    public interface IResponse
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
