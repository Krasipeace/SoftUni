namespace _02._Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char TRACKED_CAR = 'C';
            const char FINNISH = 'F';
            const int PASSED_DOT = 10;
            const int PASSED_TUNNEL = 30;
            const char TUNNELS = 'T';
            const char EMPTY_POS = '.';

            int matrixSize = int.Parse(Console.ReadLine());
            string carNumber = Console.ReadLine();

            int currentRow = 0;
            int currentCol = 0;

            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                char[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int passedDistance = 0;
            bool isFinishReached = false;

            string command = Console.ReadLine();
            while (command != "End")
            {
                matrix[currentRow, currentCol] = EMPTY_POS;

                switch (command)
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

                if (matrix[currentRow, currentCol] != TUNNELS)
                {
                    passedDistance += PASSED_DOT;
                }

                if (matrix[currentRow, currentCol] == TUNNELS)
                {
                    matrix[currentRow, currentCol] = EMPTY_POS;
                    for (int i = 0; i < matrixSize; i++)
                    {
                        for (int j = 0; j < matrixSize; j++)
                        {
                            if (matrix[i, j] == TUNNELS)
                            {
                                currentRow = i;
                                currentCol = j;
                            }
                        }
                    }
                    matrix[currentRow, currentCol] = EMPTY_POS;
                    passedDistance += PASSED_TUNNEL;
                }

                if (matrix[currentRow, currentCol] == FINNISH)
                {
                    //passedDistance += PASSED_DOT;
                    matrix[currentRow, currentCol] = TRACKED_CAR;

                    isFinishReached = true;
                    break;
                }

                matrix[currentRow, currentCol] = TRACKED_CAR;

                command = Console.ReadLine();
            }

            if (isFinishReached)
            {
                Console.WriteLine($"Racing car {carNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {carNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {passedDistance} km.");

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
