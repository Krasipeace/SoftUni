using ChristmasPastryShop.Utilities;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        public Hibernation(string name, string size) : base(name, size, Constants.COCTAIL_HIBERNATION_PRICE)
        {
        }
    }
}
