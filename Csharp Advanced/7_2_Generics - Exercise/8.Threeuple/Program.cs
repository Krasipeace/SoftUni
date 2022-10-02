using System;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] inputNameAdressCity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] inputNameBeerStatus = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] inputNameCashBank = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var nameAdressCity = new Threeuple<string, string, string>($"{inputNameAdressCity[0]} {inputNameAdressCity[1]}", inputNameAdressCity[2], inputNameAdressCity[3]);
            var nameBeerStatus = new Threeuple<string, int, bool>(inputNameBeerStatus[0], int.Parse(inputNameBeerStatus[1]), inputNameBeerStatus[2] == "drunk");
            var nameCashBank = new Threeuple<string, double, string>(inputNameCashBank[0], double.Parse(inputNameCashBank[1]), inputNameCashBank[2]);            

            Console.WriteLine(nameAdressCity);
            Console.WriteLine(nameBeerStatus);
            Console.WriteLine(nameCashBank);
        }
    }
}
