using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songList = new Queue<string>(songs);

            string command = Console.ReadLine();
            while (true)
            {
                string[] action = command.Split();

                switch (action[0])
                {
                    case "Play":
                        songList.Dequeue();
                        break;
                    case "Add":
                        string songName = string.Join(" ", action.Skip(1));
                        if (!songList.Contains(songName))
                        {
                            songList.Enqueue(songName);
                        }
                        else
                        {
                            Console.WriteLine($"{songName} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songList));
                        break;
                }

                if (songList.Count == 0)
                {
                    Console.WriteLine("No more songs!");

                    return;
                }
                command = Console.ReadLine();
            }
        }
    }
}
