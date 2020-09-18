namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        public SleepyDwarf(string name, int energy = 50) 
            : base(name, energy)
        {
        }

        public override void Work()
        {
            this.Energy -= 15;
        }
    }
}
