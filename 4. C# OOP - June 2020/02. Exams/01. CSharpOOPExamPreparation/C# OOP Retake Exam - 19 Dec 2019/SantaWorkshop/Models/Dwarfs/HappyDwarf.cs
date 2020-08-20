namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        public HappyDwarf(string name, int energy = 100) 
            : base(name, energy)
        {
        }

        public override void Work()
        {
            this.Energy -= 10;
        }
    }
}
