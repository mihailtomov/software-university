using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        public Advanced(ICardRepository cardRepository, string username, int health = 250) 
            : base(cardRepository, username, health)
        {
        }
    }
}
