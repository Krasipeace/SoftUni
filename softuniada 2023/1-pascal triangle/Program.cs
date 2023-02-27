class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[] result = PascalTriangleRow(n);
        Console.WriteLine(string.Join(" ", result));
    }

    static int[] PascalTriangleRow(int n)
    {
        int[] result = { 1 };
        for (int i = 0; i < n; i++)
        {
            int[] generateRow = new int[result.Length + 1];
            generateRow[0] = 1;
            generateRow[generateRow.Length - 1] = 1;

            for (int j = 1; j < generateRow.Length - 1; j++)
            {
                generateRow[j] = result[j - 1] + result[j];
            }

            result = generateRow;
        }
        return result;
    }
}

