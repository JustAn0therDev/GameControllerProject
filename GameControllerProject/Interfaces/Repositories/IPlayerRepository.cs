using GameControllerProject.Domain.Entities;
using System.Collections.Generic;

namespace GameControllerProject.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        //Repositório sempre devolve a entidade.
        Player Authenticate(string email, string password);
        Player AddPlayer(Player playerToBeAdded);
        List<Player> GetAllPlayers();
    }
}
