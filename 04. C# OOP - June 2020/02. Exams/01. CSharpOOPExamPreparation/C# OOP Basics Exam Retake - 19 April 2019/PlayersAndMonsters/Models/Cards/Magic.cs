namespace PlayersAndMonsters.Models.Cards
{
    public class Magic : Card
    {
        public Magic(string name, int damagePoints = 5, int healthPoints = 80) 
            : base(name, damagePoints, healthPoints)
        {
        }
    }
}
