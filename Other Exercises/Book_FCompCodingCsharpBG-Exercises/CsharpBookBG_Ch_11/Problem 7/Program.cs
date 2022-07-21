using System;
using Problem_7.Examples; //problem 7 and problem 8 combined

namespace Problem_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
          //  Console.WriteLine("Sequence[1..3]: {0}, {1}, {2}", Sequence.NextValue(), Sequence.NextValue(), Sequence.NextValue());
          //
          //  Cat someCat = new Cat();
          //  someCat.SayMiau();
          //  Console.WriteLine("The color of cat {0} is {1}.", someCat.Name, someCat.Color);
          //
          //  someCat = new Cat("Johnny", "brown");
          //  someCat.SayMiau();
          //  Console.WriteLine("The color of cat {0} is {1}.", someCat.Name, someCat.Color);

            string name = "";
            for (int i = 0; i < 10; i++)
            {
                Cat cat = new Cat(name + Sequence.NextValue(), "Black");
                cat.SayMiau();
            }
            
        }
    }
}
