using GameControllerProject.Domain.Entities.Base;
using System;

namespace GameControllerProject.Domain.Entities
{
    public class Platform : EntityBase
    {
        #region Public Members
        public string Name { get; set; }

        #endregion

        #region Constructors

        public Platform()
        {

        }
        public Platform(string name) : base()
        {
            Name = name;
        }
        public Platform(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion

    }
}
