
namespace CollectionHierarchy.Core
{
    using System;

    using CollectionHierarchy.Core.Contracts;
    using CollectionHierarchy.Models;
    using CollectionHierarchy.Models.Contracts;

    public class Engine : IEngine
    {
        public void Run()
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int removeOpCnt = int.Parse(Console.ReadLine());

            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemCollection = new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();

            AddToCollection(addCollection, words);
            AddToCollection(addRemCollection, words);
            AddToCollection(myList, words);

            RemoveFromCollection(addRemCollection, removeOpCnt);
            RemoveFromCollection(myList, removeOpCnt);
        }

        private static void AddToCollection(IAddCollection<string> collection, string[] words)
        {
            foreach (string word in words)
            {
                Console.Write(collection.Add(word) + " ");
            }

            Console.WriteLine();
        }

        private static void RemoveFromCollection(IAddRemoveCollection<string> collection, int removeOpCnt)
        {
            for (int i = 0; i < removeOpCnt; i++)
            {
                Console.Write(collection.Remove() + " ");
            }

            Console.WriteLine();
        }
    }
}

