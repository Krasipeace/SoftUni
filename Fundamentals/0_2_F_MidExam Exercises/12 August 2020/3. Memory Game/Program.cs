using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();          
            int moves = 1;

            while (true)
            {               
                string command = Console.ReadLine();                

                if (command == "end")
                {
                    break;
                }
                //user commands
                int[] elements = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int userElementOne = elements[0];
                int userElementTwo = elements[1];

                //cheating punishment
                if (userElementOne == userElementTwo || userElementOne < 0 || userElementTwo < 0 || userElementOne > inputList.Count - 1 || userElementTwo > inputList.Count - 1)
                {
                    inputList.Insert(inputList.Count / 2, $"-{moves}a");
                    inputList.Insert(inputList.Count / 2, $"-{moves}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                } 
                else if (inputList[userElementOne] == inputList[userElementTwo])                 //check matches of equal elements
                {
                    string equalElement = inputList[userElementOne];
                    inputList.Remove(equalElement);
                    inputList.Remove(equalElement);

                    Console.WriteLine($"Congrats! You have found matching elements - {equalElement}!");
                }
                else
                {
                    Console.WriteLine("Try again!");            //no equal elements
                }
                if (inputList.Count <= 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");

                    return;
                }

                moves++;
            }
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(' ', inputList));
        }
    }
}
