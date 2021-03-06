﻿using GameControllerProject.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameControllerProject.Domain.Arguments.Game
{
    public class AddGameRequest : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Productor { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Website { get; set; }
        public List<Guid> Platforms { get; set; }
    }
}
