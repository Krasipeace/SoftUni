using System;
using System.Linq;
using System.Text;

using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> repository;

        public Controller()
        {
            repository = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = repository.Models.Count + 1;
            Booth booth = new Booth(boothId, capacity);
            repository.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (size != "Large" && size != "Middle" && size != "Small")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            ICocktail cocktail = null;
            switch (cocktailTypeName)
            {
                case "Hibernation":
                    cocktail = new Hibernation(cocktailName, size);
                    break;
                case "MulledWine":
                    cocktail = new MulledWine(cocktailName, size);
                    break;
                default:
                    return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            IBooth booth = repository.Models
                .First(x => x.BoothId == boothId);

            if (booth.CocktailMenu.Models.Any(cocktail => cocktail.Name == cocktailName && cocktail.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy;
            switch (delicacyTypeName)
            {
                case "Gingerbread":
                    delicacy = new Gingerbread(delicacyName);
                    break;
                case "Stolen":
                    delicacy = new Stolen(delicacyName);
                    break;
                default:
                    return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (repository.Models.Any(r => r.DelicacyMenu.Models.Any(d => d.Name == delicacyName)))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IBooth booth = repository.Models
                .FirstOrDefault(r => r.BoothId == boothId);
            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth report = repository.Models
                .FirstOrDefault(r => r.BoothId == boothId);

            return report.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = repository.Models
                .FirstOrDefault(r => r.BoothId == boothId);

            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Bill {booth.CurrentBill:f2} lv")
                .AppendLine(string.Format(OutputMessages.BoothIsAvailable, boothId));

            booth.Charge();
            booth.ChangeStatus();

            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var freeBooth = repository.Models
                .Where(r => r.IsReserved == false && r.Capacity >= countOfPeople)
                .OrderBy(r => r.Capacity)
                .ThenByDescending(r => r.BoothId)
                .FirstOrDefault();

            if (freeBooth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            freeBooth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, freeBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderInformation = order.Split('/');
            string itemTypeName = orderInformation[0];
            string itemName = orderInformation[1];
            int countOfOrderedPieces = int.Parse(orderInformation[2]);
            string cocktailSizeIfItemIsCocktail = string.Empty;

            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                cocktailSizeIfItemIsCocktail = orderInformation[3];
            }

            if (itemTypeName != "MulledWine" && itemTypeName != "Hibernation" &&
                itemTypeName != "Gingerbread" && itemTypeName != "Stolen")
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            IBooth booth = repository.Models.First(x => x.BoothId == boothId);
            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                if (!booth.CocktailMenu.Models.Any(cocktail => cocktail.Name == itemName))
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
                }
            }
            else if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                if (!booth.DelicacyMenu.Models.Any(delicacy => delicacy.Name == itemName))
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }
            }

            ICocktail cocktail = null;
            if (cocktailSizeIfItemIsCocktail != "")
            {
                cocktail = booth.CocktailMenu.Models
                    .FirstOrDefault(x => x.Name == itemName);
                if (!booth.CocktailMenu.Models.Any(x => x.Name == itemName && x.GetType().Name == itemTypeName && x.Size == cocktailSizeIfItemIsCocktail))
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, cocktailSizeIfItemIsCocktail, itemName);
                }

                booth.UpdateCurrentBill(cocktail.Price * countOfOrderedPieces);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }

            IDelicacy delicacy = booth.DelicacyMenu.Models
                .FirstOrDefault(x => x.Name == itemName);
            if (!booth.DelicacyMenu.Models.Any(x => x.Name == itemName && x.GetType().Name == itemTypeName))
            {
                return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
            }

            booth.UpdateCurrentBill(delicacy.Price * countOfOrderedPieces);

            return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
        }
    }
}
