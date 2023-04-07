using ChristmasPastryShop.Utilities;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        public Gingerbread(string name) : base(name, Constants.DELICACY_GINGERBREAD_PRICE)
        {
        }
    }
}
