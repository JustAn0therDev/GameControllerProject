﻿using GameControllerProject.Domain.Interfaces.Arguments;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class AuthenticatePlayerResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        //"Explicit operator" converte de um tipo para outro.
        //Esse tipo de método deve ser estático e deve estar presente na classe para qual o objeto em questão será convertido ou
        //na classe que recebe a conversão.
        public static explicit operator AuthenticatePlayerResponse(Entities.Player player)
        {
            return new AuthenticatePlayerResponse()
            {
                Success = true,
                FirstName = player.Name.FirstName,
                Email = player.Email.Address,
                Message = "Player successfully authenticated"
            };
        }
    }
}
