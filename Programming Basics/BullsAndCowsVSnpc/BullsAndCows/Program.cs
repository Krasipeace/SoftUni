using System;

namespace BullsAndCows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     ***   B  U  L  L  S    A  N  D    C  O  W  S   ***     ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("Bulls and Cows is a logic game for guessing the number invented by the computer.");
            Console.WriteLine("After each move, the computer gives the number of matches. ");
            Console.WriteLine("If a number of the conjecture is contained in the secret number and is in the right place,");
            Console.WriteLine("it is BULL, if it is in a different place, it is COW.");
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Write iGiveUp to admit Defeat!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;          

            int pcNumber = new Random().Next(1000, 9999);

            //Console.WriteLine(pcNumber);                                      //shows PC number

            int cgOne = pcNumber / 1000 % 10;
            int cgTwo = pcNumber / 100 % 10;
            int cgThree = pcNumber / 10 % 10;
            int cgFour = pcNumber / 1 % 10;
            string input = string.Empty;
            int counter = 0;

            //Console.WriteLine($"{cgOne} + {cgTwo} + {cgThree} + {cgFour}");   //checking validity of number

            while (true)
            {
                Console.Write("Enter number (4 digits): ");                     //bugs, if you add letter + number.
                input = Console.ReadLine();
                counter++;

                if (input == "iGiveUp")
                {
                    counter -= 1;
                    if (counter <= 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"You have been DEFEATED! Computer won after {counter} try...");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"You have been DEFEATED! Computer won after {counter} tries...");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    return;                    
                }

                int userNumber = int.Parse(input);

                int userOne = userNumber / 1000 % 10;
                int userTwo = userNumber / 100 % 10;
                int userThree = userNumber / 10 % 10;
                int userFour = userNumber / 1 % 10;


                while (input != "iGiveUp")
                {
                    int bullCounter = 0;
                    int cowsCounter = 0;
                    if (userOne == cgOne)
                    {
                        bullCounter++;                                               
                    }
                    if (userTwo == cgTwo)
                    {
                        bullCounter++;                                              
                    }
                    if (userThree == cgThree)
                    {
                        bullCounter++;                                              
                    }
                    if (userFour == cgFour)
                    {
                        bullCounter++;                                             
                    }
                    if (bullCounter == 4)
                    {
                        
                        if (counter <= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Lucky Guess! You have found the lost Bulls on the first try!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"VICTORY! You have found the lost Bulls after {counter} tries!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        return;
                    }

                    if (userOne == cgTwo || userOne == cgThree || userOne == cgFour)
                    {
                        cowsCounter++;                      
                    }
                    if (userTwo == cgOne || userTwo == cgThree || userTwo == cgFour)
                    {
                        cowsCounter++;                       
                    }
                    if (userThree == cgOne || userThree == cgTwo || userThree == cgFour)
                    {
                        cowsCounter++;                       
                    }
                    if (userFour == cgOne || userFour == cgTwo || userFour == cgThree)
                    {
                        cowsCounter++;                       
                    }

                    if (cowsCounter <= 4 || bullCounter < 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Keep trying you have found {bullCounter} bulls and {cowsCounter} cows...");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;                                          
                    }

                }

            }
        }
    }
}
