namespace PlayersAndMonsters.Models.Cards
{
    public class Trap : Card
    {
        public Trap(string name, int damagePoints = 120, int healthPoints = 5) 
            : base(name, damagePoints, healthPoints)
        {
        }
    }
}
