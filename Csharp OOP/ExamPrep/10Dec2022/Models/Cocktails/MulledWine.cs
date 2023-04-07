using ChristmasPastryShop.Utilities;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        public MulledWine(string cocktailName, string size) : base(cocktailName, size, Constants.COCTAIL_MULLEDWINE_PRICE)
        {
        }
    }
}
