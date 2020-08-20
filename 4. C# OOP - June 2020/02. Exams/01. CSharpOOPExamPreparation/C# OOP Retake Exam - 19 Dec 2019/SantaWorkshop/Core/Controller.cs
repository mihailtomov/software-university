using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Enumerations;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private readonly DwarfRepository dwarfs;
        private readonly PresentRepository presents;
        private readonly Workshop workshop;
        private int craftedPresentsCount;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
            this.workshop = new Workshop();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            Enum.TryParse(dwarfType, out DwarfType dwarfTypeEnum);

            switch (dwarfTypeEnum)
            {
                case DwarfType.HappyDwarf:
                    this.dwarfs.Add(new HappyDwarf(dwarfName));
                    break;
                case DwarfType.SleepyDwarf:
                    this.dwarfs.Add(new SleepyDwarf(dwarfName));
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            string msg = string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
            return msg;
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = this.dwarfs.FindByName(dwarfName);

            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            Instrument instrument = new Instrument(power);
            dwarf.AddInstrument(instrument);

            string msg = string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
            return msg;
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            Present present = new Present(presentName, energyRequired);
            this.presents.Add(present);

            string msg = string.Format(OutputMessages.PresentAdded, presentName);
            return msg;
        }

        public string CraftPresent(string presentName)
        {
            IPresent present = this.presents.FindByName(presentName);

            if (!this.dwarfs.Models.Any(d => d.Energy >= 50))
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            List<IDwarf> readyDwarfs = this.dwarfs.Models
                .Where(d => d.Energy >= 50)
                .OrderByDescending(d => d.Energy)
                .ToList();

            for (int i = 0; i < readyDwarfs.Count; i++)
            {
                IDwarf currDwarf = readyDwarfs[i];

                this.workshop.Craft(present, currDwarf);

                if (currDwarf.Energy == 0)
                {
                    this.dwarfs.Remove(currDwarf);
                }
            }

            string msg; 

            if (present.IsDone())
            {
                msg = string.Format(OutputMessages.PresentIsDone, present.Name);
                craftedPresentsCount++;
            }
            else
            {
                msg = string.Format(OutputMessages.PresentIsNotDone, present.Name);
            }

            return msg;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{craftedPresentsCount} presents are done!");
            sb.AppendLine($"Dwarfs info:");

            foreach (var dwarf in this.dwarfs.Models)
            {
                sb.AppendLine(dwarf.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
