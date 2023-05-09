namespace _02._Navy_Battle
{
    internal class Program
    {
        private const char EmptyPos = '-';
        private const char SubmarinePos = 'S';
        private const char MinePos = '*';
        private const char EnemyShipPos = 'C';

        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int currentRow = -1;
            int currentCol = -1;
            int mines = 0;
            int ships = 0;

            char[,] field = InitializeField(fieldSize, ref currentRow, ref currentCol);

            GetBattlefield(ref currentRow, ref currentCol, ref mines, ref ships, field);

            GetResult(field);
        }

        private static char[,] InitializeField(int fieldSize, ref int currentRow, ref int currentCol)
        {
            char[,] field = new char[fieldSize, fieldSize];
            for (int i = 0; i < fieldSize; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < fieldSize; j++)
                {
                    if (input[j] == SubmarinePos)
                    {
                        currentRow = i;
                        currentCol = j;
                    }
                    field[i, j] = input[j];
                }
            }

            return field;
        }

        private static void GetBattlefield(ref int currentRow, ref int currentCol, ref int mines, ref int ships, char[,] field)
        {
            while (true)
            {
                GetDirection(ref currentRow, ref currentCol, field);

                if (field[currentRow, currentCol] == EmptyPos)
                {
                    field[currentRow, currentCol] = SubmarinePos;
                }
                else if (field[currentRow, currentCol] == EnemyShipPos)
                {
                    field[currentRow, currentCol] = SubmarinePos;
                    ships++;
                    if (ships == 3)
                    {
                        Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                        break;
                    }
                }
                else if (field[currentRow, currentCol] == MinePos)
                {
                    field[currentRow, currentCol] = SubmarinePos;
                    mines++;
                    if (mines == 3)
                    {
                        Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{currentRow}, {currentCol}]!");
                        break;
                    }
                }
            }
        }

        private static void GetDirection(ref int currentRow, ref int currentCol, char[,] field)
        {
            field[currentRow, currentCol] = EmptyPos;

            string comand = Console.ReadLine();
            switch (comand)
            {
                case "up":
                    currentRow--;
                    break;
                case "down":
                    currentRow++;
                    break;
                case "left":
                    currentCol--;
                    break;
                case "right":
                    currentCol++;
                    break;
            }
        }

        private static void GetResult(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
