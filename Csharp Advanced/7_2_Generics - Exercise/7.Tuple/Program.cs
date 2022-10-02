using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] inputNameAdress = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] inputNameBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] inputIntegerDouble = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var nameAdress = new Tuple<string, string>($"{inputNameAdress[0]} {inputNameAdress[1]}", inputNameAdress[2]);
            var nameBeer = new Tuple<string, int>(inputNameBeer[0], int.Parse(inputNameBeer[1]));
            var integerDouble = new Tuple<int, double>(int.Parse(inputIntegerDouble[0]), double.Parse(inputIntegerDouble[1]));

            Console.WriteLine(nameAdress);
            Console.WriteLine(nameBeer);
            Console.WriteLine(integerDouble);
        }
    }
}
