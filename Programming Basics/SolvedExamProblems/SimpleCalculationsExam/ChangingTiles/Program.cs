using System;

namespace ChangingTiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengthGround = int.Parse(Console.ReadLine());
            double widthTile = double.Parse(Console.ReadLine());
            double lengthTile = double.Parse(Console.ReadLine());
            int widthBench = int.Parse(Console.ReadLine());
            int lengthBench = int.Parse(Console.ReadLine());

            double areaGround = lengthGround * lengthGround;
            double areaBench = widthBench * lengthBench;
            double areaTiles = widthTile * lengthTile;
            double areaBuildTiles = areaGround - areaBench;
            double tiles = areaBuildTiles / areaTiles;
            double time = tiles * 0.2;
            Console.WriteLine(tiles);
            Console.WriteLine(time);
        }
    }
}
