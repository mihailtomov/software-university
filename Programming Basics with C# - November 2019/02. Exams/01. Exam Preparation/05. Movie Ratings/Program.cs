using System;

namespace _05._Movie_Ratings
{
    class Program
    {
        static void Main(string[] args)
        {
            int movieCount = int.Parse(Console.ReadLine());

            string bestMovieName = string.Empty;
            string worstMovieName = string.Empty;

            double bestMovieRating = double.MinValue;
            double worstMovieRating = double.MaxValue;

            double ratingSum = 0.0;

            for (int i = 0; i < movieCount; i++)
            {
                string currentMovieName = Console.ReadLine();
                double currentMovieRating = double.Parse(Console.ReadLine());

                ratingSum += currentMovieRating;

                if (currentMovieRating > bestMovieRating)
                {
                    bestMovieName = currentMovieName;
                    bestMovieRating = currentMovieRating;
                }

                else if (currentMovieRating < worstMovieRating)
                {
                    worstMovieName = currentMovieName;
                    worstMovieRating = currentMovieRating;
                }
            }

            double averageRating = ratingSum / movieCount;

            Console.WriteLine($"{bestMovieName} is with highest rating: {bestMovieRating:f1}");
            Console.WriteLine($"{worstMovieName} is with lowest rating: {worstMovieRating:f1}");
            Console.WriteLine($"Average rating: {averageRating:f1}");

        }
    }
}
