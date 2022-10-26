using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList strings = new RandomList();

            strings.Add("1");
            strings.Add("2");
            strings.Add("3");

            Console.WriteLine(strings.RandomString());
        }
    }
}
