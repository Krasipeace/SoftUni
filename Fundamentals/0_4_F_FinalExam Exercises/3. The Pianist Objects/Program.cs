using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._The_Pianist_Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pieces = new List<Piece>();

            int inputLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputLines; i++)
            {
                string[] musicInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

                Piece piece = new Piece()
                {
                    Name = musicInfo[0],
                    Composer = musicInfo[1],
                    Key = musicInfo[2],
                };
                pieces.Add(piece);

            }

            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] action = command.Split('|', StringSplitOptions.RemoveEmptyEntries);               

                switch (action[0])
                {
                    case "Add":                                       //"Add|{piece}|{composer}|{key}"                        
                        Add(action, pieces);
                        break;
                    case "Remove":                                    //Remove|{piece}"
                        Remove(action, pieces);
                        break;
                    case "ChangeKey":                                 //ChangeKey|{piece}|{new key}
                        ChangeKey(action, pieces);
                        break;
                }

                command = Console.ReadLine();
            }

            foreach (Piece song in pieces)
            {
                Console.WriteLine($"{song.Name} -> Composer: {song.Composer}, Key: {song.Key}");
            }
        }

        private static void Add(string[] action, List<Piece> pieces)
        {
            string pieceName = action[1];
            string pieceComposer = action[2];
            string pieceKey = action[3];

            if (!pieces.Any(p => p.Name == pieceName))                
            {
                Piece piece = new Piece()
                {
                    Name = pieceName,
                    Composer = pieceComposer,
                    Key = pieceKey
                };

                pieces.Add(piece);
                Console.WriteLine($"{piece.Name} by {piece.Composer} in {piece.Key} added to the collection!");
            }
            else
            {
                Console.WriteLine($"{pieceName} is already in the collection!");
            }
        }

        private static void Remove(string[] action, List<Piece> pieces)
        {
            string pieceName = action[1];

            if (pieces.Any(p => p.Name == pieceName))
            {
                pieces.RemoveAll(x => x.Name == pieceName);                       //removing all elements of certain pieceName

                Console.WriteLine($"Successfully removed {pieceName}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
            }
        }

        private static void ChangeKey(string[] action, List<Piece> pieces)
        {
            string pieceName = action[1];
            string pieceKey = action[2];

            if (pieces.Any(p => p.Name == pieceName))
            {              
                Piece piece = pieces.First(currPiece => currPiece.Name == pieceName);
                piece.Key = pieceKey;

                Console.WriteLine($"Changed the key of {pieceName} to {pieceKey}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
            }
        }
    }
    public class Piece
    {
        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

    }
}
