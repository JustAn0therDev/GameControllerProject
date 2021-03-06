﻿using GameControllerProject.Domain.Interfaces.Arguments;
using GameControllerProject.Domain.ValueObjects;

namespace GameControllerProject.Domain.Arguments.Player
{
    public class AddPlayerRequest : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
