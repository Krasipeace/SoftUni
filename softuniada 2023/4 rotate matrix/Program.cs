namespace RotateMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            ReadInitialMatrix(size, matrix);

            int[,] rotatedMatrix = RotateMatrix(matrix, size);

            PrintRotatedMatrix(size, rotatedMatrix);
        }


        private static void ReadInitialMatrix(int size, int[,] matrix)
        {
            for (int i = 0; i < size; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                }
            }
        }

        private static int[,] RotateMatrix(int[,] matrix, int size)
        {
            int[,] rotatedMatrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    rotatedMatrix[j, size - 1 - i] = matrix[i, j];
                }
            }

            return rotatedMatrix;
        }

        private static void PrintRotatedMatrix(int size, int[,] rotatedMatrix)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{rotatedMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
