using System;

namespace GenericBoxOfString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputs; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                Console.WriteLine(box.ToString());
            }       
        }
    }
}
