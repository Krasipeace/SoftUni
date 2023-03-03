using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            this.InitializeGameField();
        }

        public bool IsPointsOfWall(Point snakeElement)
            => snakeElement.LeftX == 0 || snakeElement.LeftX == this.LeftX - 1
            || snakeElement.TopY == 0 || snakeElement.TopY == this.TopY;

        public void InitializeGameField()
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY);
            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX - 1);
        }

        private void SetHorizontalLine(int topY)
        {
            for (int i = 0; i < this.LeftX; i++)
            {
                this.Draw(i, topY, Constants.WALL_SYMBOL);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int i = 0; i < TopY; i++)
            {
                this.Draw(leftX, i, Constants.WALL_SYMBOL);
            }
        }
    }
}
