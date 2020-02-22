using GameControllerProject.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameControllerProject.Domain.Arguments.Game
{
    public class DeleteGameResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
