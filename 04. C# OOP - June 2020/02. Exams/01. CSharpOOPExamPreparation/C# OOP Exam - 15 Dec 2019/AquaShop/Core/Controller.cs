using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Enumerations;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private readonly List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            Enum.TryParse(aquariumType, out AquariumType aquariumTypeEnum);

            switch (aquariumTypeEnum)
            {
                case AquariumType.FreshwaterAquarium:
                    this.aquariums.Add(new FreshwaterAquarium(aquariumName));
                    break;
                case AquariumType.SaltwaterAquarium:
                    this.aquariums.Add(new SaltwaterAquarium(aquariumName));
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            string msg = string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            return msg;
        }

        public string AddDecoration(string decorationType)
        {
            Enum.TryParse(decorationType, out DecorationType decorationTypeEnum);

            switch (decorationTypeEnum)
            {
                case DecorationType.Ornament:
                    this.decorations.Add(new Ornament());
                    break;
                case DecorationType.Plant:
                    this.decorations.Add(new Plant());
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            string msg = string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            return msg;
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);

            Enum.TryParse(fishType, out FishType fishTypeEnum);

            if (fishTypeEnum != FishType.FreshwaterFish && fishTypeEnum != FishType.SaltwaterFish)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if ((aquarium.GetType().Name == "FreshwaterAquarium" && fishTypeEnum == FishType.FreshwaterFish)
                || (aquarium.GetType().Name == "SaltwaterAquarium" && fishTypeEnum == FishType.SaltwaterFish))
            {
                switch (fishTypeEnum)
                {
                    case FishType.FreshwaterFish:
                        aquarium.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
                        break;
                    case FishType.SaltwaterFish:
                        aquarium.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
                        break;
                }

                string msg = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                return msg;
            }

            return OutputMessages.UnsuitableWater;
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);

            decimal value = aquarium.Decorations.Sum(d => d.Price) + aquarium.Fish.Sum(f => f.Price);

            string msg = string.Format(OutputMessages.AquariumValue, aquariumName, value);
            return msg;
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);

            aquarium.Feed();

            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);

            IDecoration decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                string msg = string.Format(ExceptionMessages.InexistentDecoration, decorationType);
                throw new InvalidOperationException(msg);
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);
            string result = string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
