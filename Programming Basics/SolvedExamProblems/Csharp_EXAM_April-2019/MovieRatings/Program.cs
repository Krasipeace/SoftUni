using System;

namespace MovieRatings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int movies = int.Parse(Console.ReadLine());
            double averageRating = 0;
            double maxRating = 0;
            double minRating = 10;
            double current = 0;
            int counter = 0;
            double sumRating = 0;
            string movieMax = string.Empty;
            string movieMin = string.Empty; 

            for (int i = 1; i <= movies; i++)
            {
                string movieTitle = Console.ReadLine();
                double movieRating = double.Parse(Console.ReadLine());
                current = movieRating;
                counter++;
                sumRating += movieRating;

                if (current > maxRating)
                {
                    maxRating = current;
                    movieMax = movieTitle;
                }
                if (current <= minRating)
                {
                    minRating = current;
                    movieMin = movieTitle;
                }                                              
            }
            averageRating = sumRating / counter;

            Console.WriteLine($"{movieMax} is with highest rating: {maxRating:f1}");
            Console.WriteLine($"{movieMin} is with lowest rating: {minRating:f1}");
            Console.WriteLine($"Average rating: {averageRating:f1}");
        }
    }
}
