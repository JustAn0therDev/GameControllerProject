using GameControllerProject.Domain.Arguments.Player;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Domain.Services;
using System;

namespace GameControllerProject.AppConsole
{
    public class Program
    {
        public static IPlayerRepository _playerRepository;
        static void Main()
        {
            Console.WriteLine("Initialing program...");

            PlayerService playerService = new PlayerService(_playerRepository);
            Console.WriteLine("Instance of PlayerService class created.");

            AuthenticatePlayerRequest request = new AuthenticatePlayerRequest();
            Console.WriteLine("Request object instance created");
            request.Email = "ruanmontelo@gmail.com";
            request.Password = "SuperNintendo14";

            AuthenticatePlayerResponse response = playerService.Authenticate(request);

            if (response == null)
                Console.WriteLine("Invalid request");
            else
                Console.WriteLine(response.Message);


            Console.ReadKey();
        }
    }
}
