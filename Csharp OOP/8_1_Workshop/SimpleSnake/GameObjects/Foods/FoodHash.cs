using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        public FoodHash(Wall wall)
            : base(wall, Constants.FOOD_HASH_SYMBOL, Constants.FOOD_HASH_POINTS, Constants.FOOD_HASH_COLOR)
        {
        }
    }
}
