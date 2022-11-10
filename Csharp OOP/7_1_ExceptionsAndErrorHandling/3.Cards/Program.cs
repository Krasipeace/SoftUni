using System;
using System.Collections.Generic;

namespace _3.Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> deck = new List<Card>();
            string[] sequence = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < sequence.Length; i++)
            {
                string[] tokens = sequence[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string face = tokens[0];
                string suit = tokens[1];

                try
                {
                    Card card = Card.DrawCard(face, suit);
                    deck.Add(card);
                }
                catch (ArgumentException arg)
                {
                    Console.WriteLine(arg.Message);
                }
            }

            Console.WriteLine(string.Join(" ", deck));
        }
    }

    public class Card
    {
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }
        public string Face { get; set; }
        public string Suit { get; set; }
        public static Card DrawCard(string face, string suit)
        {
            List<string> suits = new List<string>()
            {
                "S", "H", "D", "C"
            };
            List<string> faces = new List<string>()
            {
                "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };

            if (!faces.Contains(face) || !suits.Contains(suit))
            {
                throw new ArgumentException("Invalid card!");
            }

            string symbol = string.Empty;
            switch (suit)
            {
                case "S": 
                    symbol = "\u2660"; 
                    break;
                case "H": 
                    symbol = "\u2665"; 
                    break;
                case "D": 
                    symbol = "\u2666"; 
                    break;
                case "C": 
                    symbol = "\u2663"; 
                    break;
            }

            return new Card(face, symbol);
        }
        public override string ToString() => $"[{Face}{Suit}]";
    }
}
