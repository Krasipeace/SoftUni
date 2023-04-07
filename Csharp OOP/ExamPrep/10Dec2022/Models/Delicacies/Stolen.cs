using ChristmasPastryShop.Utilities;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        public Stolen(string name) : base(name, Constants.DELICACY_STOLEN_PRICE)
        {
        }
    }
}
