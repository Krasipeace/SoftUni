using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodPercent : Food
    {
        public FoodPercent(Wall wall)
            : base(wall, Constants.FOOD_PERCENT_SYMBOL, Constants.FOOD_PERCENT_POINTS, Constants.FOOD_PERCENT_COLOR)
        {
        }
    }
}
