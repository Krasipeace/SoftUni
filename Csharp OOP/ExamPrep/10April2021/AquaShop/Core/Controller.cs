namespace AquaShop.Core
{
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Repositories;
    using AquaShop.Repositories.Contracts;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case "SaltwaterAquarium":
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            {
                IDecoration decoration;
                switch (decorationType)
                {
                    case "Ornament":
                        decoration = new Ornament();
                        break;
                    case "Plant":
                        decoration = new Plant();
                        break;
                    default:
                        throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
                }
                decorations.Add(decoration);

                return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            IAquarium aquarium = aquariums.First(x => x.Name == aquariumName);
            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = aquariums.First(x => x.Name == aquariumName);
            IFish fish;

            switch (fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    if (aquarium.GetType().Name != "FreshwaterAquarium")
                    {
                        return OutputMessages.UnsuitableWater;
                    }
                    break;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    if (aquarium.GetType().Name != "SaltwaterAquarium")
                    {
                        return OutputMessages.UnsuitableWater;
                    }
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            aquarium.AddFish(fish);

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(x => x.Name == aquariumName);
            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(x => x.Name == aquariumName);
            decimal aquariumValue = aquarium.Decorations.Sum(x => x.Price) + aquarium.Fish.Sum(x => x.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, aquariumValue);
        }

        public string Report()
        {
            return string.Join(Environment.NewLine, aquariums.Select(x => x.GetInfo().TrimEnd()));
        }
    }
}
