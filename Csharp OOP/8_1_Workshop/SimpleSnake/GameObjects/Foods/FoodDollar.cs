using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        public FoodDollar(Wall wall)
            : base(wall, Constants.FOOD_DOLLAR_SYMBOL, Constants.FOOD_DOLLAR_POINTS, Constants.FOOD_DOLLAR_COLOR)
        {
        }
    }
}
