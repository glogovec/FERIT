using System;
using TvSeriesLibrary;

namespace TvSeriesUi
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomGenerator = new Random();
            Episode ep1 = new Episode();
            Episode ep2 = new Episode(10, 64.39, 8.7);

            int viewers = 10;

            for (int i = 0; i < viewers; i++)
            {
                ep1.AddView(GenerateRandomScore(randomGenerator));
                Console.WriteLine(ep1.GetMaxScore());
            }

            if (ep1.GetAverageScore() > ep2.GetAverageScore())
            {
                Console.WriteLine($"Viewers: {ep1.GetViewerCount()}");
            }

            else
            {
                Console.WriteLine($"Viewers: {ep2.GetViewerCount()}");
            }
        }
        public static double GenerateRandomScore(Random randomGenerator){ // uses one seed that is set in main
          
            return randomGenerator.NextDouble() * 10; // NextDouble() generates doubles from 0.0 do 1.0 so we have to multiply it by 10 
        }
    }
}
