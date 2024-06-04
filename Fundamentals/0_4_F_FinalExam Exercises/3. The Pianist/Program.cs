using System;
using System.Collections.Generic;

namespace _03The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var music = new Dictionary<string, KeyValuePair<string, string>>();
            var order = new List<string>();

            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                var musicInfo = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                //Fur Elise
                string piece = musicInfo[0];
                //Beethoven
                string composer = musicInfo[1];
                //A Minor
                string key = musicInfo[2];

                if (!music.ContainsKey(piece))
                {
                    music.Add(piece, new KeyValuePair<string, string>(composer, key));
                    order.Add(piece);
                }
            }

            string play = Console.ReadLine();

            while (play != "Stop")
            {
                string[] commands = play.Split("|");
                string piece = commands[1];

                // commands[0] => Add, ChangeKey, Remove
                switch (commands[0])
                {
                    case "Add":
                        {                          
                            string composer = commands[2];
                            string key = commands[3];

                            if (!music.ContainsKey(piece))
                            {
                                music.Add(piece, new KeyValuePair<string, string>(composer, key));
                                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                                order.Add(piece);
                            }
                            else
                            {
                                Console.WriteLine($"{piece} is already in the collection!");
                            }                            
                        }
                        break;
                    case "Remove":
                    {
                        if (music.ContainsKey(piece))
                        {
                            music.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                            order.Remove(piece);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }                        
                    }
                        break;
                    case "ChangeKey":
                        string newKey = commands[2];
                        if (music.ContainsKey(piece))
                        {
                            var pieceData = music[piece];
                            var composer = pieceData.Key;
                            music[piece] = new KeyValuePair<string, string>(composer, newKey);
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;
                }

                play = Console.ReadLine();
            }

            foreach (var piece in order)
            {
                Console.WriteLine($"{piece} -> Composer: {music[piece].Key}, Key: {music[piece].Value}");
            }
        }
    }
}
