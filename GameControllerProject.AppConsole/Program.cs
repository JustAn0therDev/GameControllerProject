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

            var playerService = new PlayerService(_playerRepository);
            Console.WriteLine("Instance of PlayerService class created.");

            var request = new ModifyPlayerRequest();
            Console.WriteLine("Request object instance created");
            request.Email = "ruanmontelo@gmail.com";
            request.FirstName = "Ruan";
            request.LastName = "Montelo";

            var response = playerService.ModifyPlayer(request);

            if (response == null)
                Console.WriteLine("Invalid request");
            else
                Console.WriteLine(response.Message);

            Console.ReadKey();
        }
    }
}
