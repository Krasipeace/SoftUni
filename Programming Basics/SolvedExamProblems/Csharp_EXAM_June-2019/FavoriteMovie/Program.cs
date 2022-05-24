using System;

namespace FavoriteMovie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int countMovies = 0;
            int maxSum = int.MinValue;
            string bestMovie = "";
            while (movie != "STOP")
            {
                countMovies++;
                int sum = 0;
                for (int i = 0; i < movie.Length; i++)
                {
                    char currentLetter = movie[i];

                    if (currentLetter >= 97 && currentLetter <= 122)
                    {
                        sum += (currentLetter - 2 * movie.Length);

                    }
                    else if (currentLetter >= 65 && currentLetter <= 90)
                    {
                        sum += (currentLetter - movie.Length);
                    }
                    else
                    {
                        sum += currentLetter;
                    }

                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    bestMovie = movie;
                }

                if (countMovies == 7)
                {
                    Console.WriteLine("The limit is reached.");
                    break;
                }

                movie = Console.ReadLine();
            }
            Console.WriteLine($"The best movie for you is {bestMovie} with {maxSum} ASCII sum.");
        }
    }
}
