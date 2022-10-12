using System;
using System.Linq;

namespace _2.Collection
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] create = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            ListyIterator<string> listyIterator = new ListyIterator<string>(create);

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {                   
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        listyIterator.Print();
                        break;
                    case "PrintAll":
                        listyIterator.PrintAll();
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
