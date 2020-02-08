using System;
using GameControllerProject.Domain.Entities;
using System.Collections.Generic;

namespace GameControllerProject.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        //Repositório sempre devolve a entidade a menos que esteja realizando um update.
        Player Authenticate(string email, string password);
        Player AddPlayer(Player playerToBeAdded);
        List<Player> GetAllPlayers();
        Player GetPlayerById(Guid id);
        void ModifyPlayer(Player playerToBeModified);
    }
}
