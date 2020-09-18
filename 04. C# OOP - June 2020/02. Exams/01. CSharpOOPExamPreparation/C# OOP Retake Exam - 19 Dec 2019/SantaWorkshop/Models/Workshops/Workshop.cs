using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System.Linq;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (present.IsDone() == false && dwarf.Energy > 0 && dwarf.Instruments.Any(i => i.IsBroken() == false))
            {
                IInstrument instrument = dwarf.Instruments.First(i => i.IsBroken() == false);

                dwarf.Work();
                instrument.Use();
                present.GetCrafted();
            }
        }
    }
}
