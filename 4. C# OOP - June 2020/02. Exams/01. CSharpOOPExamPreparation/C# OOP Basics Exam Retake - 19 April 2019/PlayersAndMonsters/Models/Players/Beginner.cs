using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        public Beginner(ICardRepository cardRepository, string username, int health = 50) 
            : base(cardRepository, username, health)
        {
        }
    }
}
