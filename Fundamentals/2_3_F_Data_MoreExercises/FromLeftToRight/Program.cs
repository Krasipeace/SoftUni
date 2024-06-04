namespace Demo;

public class CompareAndSumDigits
{
    public static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < input; i++)
        {
            long greaterLeft = 0;
            long greaterRight = 0;

            string[] numbers = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string left = numbers[0];
            string right = numbers[1];

            long numberLeft = long.Parse(left);
            long numberRight = long.Parse(right);

            greaterLeft = Calculate(greaterLeft, left);
            greaterRight = Calculate(greaterRight, right);

            Console.WriteLine(numberLeft > numberRight ? greaterLeft : greaterRight);
        }
    }

    private static long Calculate(long greaterSide, string side)
    {
        for (int l = 0; l < side.Length; l++)
        {
            bool isDigit = long.TryParse(side[l].ToString(), out long digit);
            greaterSide += digit;
        }

        return greaterSide;
    }
}
