using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int DATURA_BOMB_POINTS = 40;
            const int CHERRY_BOMB_POINTS = 60;
            const int SMOKE_BOMB_POINTS = 120;
            const int FILLED_POUCH_QUANTITY = 3;
            const int DECREASE_CASING_POINTS = 5;

            int daturaBombsCounter = 0;
            int cherryBombsCounter = 0;
            int smokeBombsCounter = 0;
            int sumPoints = 0;

            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ").Select(e => int.Parse(e)).ToArray());
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ").Select(c => int.Parse(c)).ToArray());

            while (bombEffects.Count != 0 && bombCasings.Count != 0)
            {
                if (daturaBombsCounter >= FILLED_POUCH_QUANTITY && cherryBombsCounter >= FILLED_POUCH_QUANTITY && smokeBombsCounter >= FILLED_POUCH_QUANTITY)
                {
                    break;
                }

                sumPoints = bombEffects.Peek() + bombCasings.Peek();
                switch (sumPoints)
                {
                    case DATURA_BOMB_POINTS:
                        daturaBombsCounter++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        break;
                    case CHERRY_BOMB_POINTS:
                        cherryBombsCounter++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        break;
                    case SMOKE_BOMB_POINTS:
                        smokeBombsCounter++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        break;
                    default:
                        bombCasings.Push(bombCasings.Pop() - DECREASE_CASING_POINTS);
                        break;
                }
            }

            GetBombsData(FILLED_POUCH_QUANTITY, daturaBombsCounter, cherryBombsCounter, smokeBombsCounter, bombEffects, bombCasings);

            PrintBombs(daturaBombsCounter, cherryBombsCounter, smokeBombsCounter);
        }

        static void GetBombsData(int FILLED_POUCH_QUANTITY, int daturaBombsCounter, int cherryBombsCounter, int smokeBombsCounter, Queue<int> bombEffects, Stack<int> bombCasings)
        {
            if (daturaBombsCounter >= FILLED_POUCH_QUANTITY && cherryBombsCounter >= FILLED_POUCH_QUANTITY && smokeBombsCounter >= FILLED_POUCH_QUANTITY)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count != 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Count != 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }
        }
        static void PrintBombs(int daturaBombsCounter, int cherryBombsCounter, int smokeBombsCounter)
        {
            Console.WriteLine($"Cherry Bombs: {cherryBombsCounter}");
            Console.WriteLine($"Datura Bombs: {daturaBombsCounter}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeBombsCounter}");
        }
    }
}
