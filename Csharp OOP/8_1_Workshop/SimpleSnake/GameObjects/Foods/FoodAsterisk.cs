using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        public FoodAsterisk(Wall wall) 
            : base(wall, Constants.FOOD_ASTERISK_SYMBOL, Constants.FOOD_ASTERISK_POINTS, Constants.FOOD_ASTERISK_COLOR)
        {
        }
    }
}
