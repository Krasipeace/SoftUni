using System;

namespace CustomListClass
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Console.WriteLine(list.ToString());

            list.Swap(1, 2); //changes elements of index 1 and 2
            Console.WriteLine(list.ToString());

            list.Insert(0, 3); //inserts 3 at index 0
            Console.WriteLine(list.ToString());

            list.Contains(3);
            Console.WriteLine(list.ToString());


        }
    }
}
