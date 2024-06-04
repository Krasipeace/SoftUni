using System;
using System.Collections.Generic;

namespace _3._SoftUni_Karaoke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                List<KaraokeSinger> singers = new List<KaraokeSinger>();

                string[] participants = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
                string[] songs = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

                int counter = 0;

                while (true)
                {
                    string command = Console.ReadLine();
                    if (command == "dawn")
                    {
                        break;
                    }

                    string[] performance = command.Split(",", StringSplitOptions.RemoveEmptyEntries);

                    counter = performance.Length;

                    string participant = performance[0];
                    string song = performance[1];
                    string award = performance[2];

                    KaraokeSinger karaokeSinger = new KaraokeSinger()
                    {
                        Name = participant,
                        Song = song,
                        Award = award
                    };
                    singers.Add(karaokeSinger);
                }

                if (counter == null)
                {
                    Console.WriteLine("No awards");
                }
                else
                {
                }
            }
        }
    }

    public class KaraokeSinger
    {
        public string Name { get; set; }
        public string Song { get; set; }
        public string Award { get; set; }
    }
}
