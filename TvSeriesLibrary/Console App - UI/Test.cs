using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvSeriesLibrary;

namespace TvSeriesLibrary
{
    public static class Test
    {
        public static void HomeworkI()
        {
            Random randomGenerator = new Random();
            Episode ep1 = new Episode();
            Episode ep2 = new Episode(10, 64.39, 8.7, null);

            int viewers = 10;

            for (int i = 0; i < viewers; i++)
            {
                ep1.AddView(TvUtilities.GenerateRandomScore(randomGenerator));
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
        public static void HomeworkII()
        {
            Description description = new Description(1, TimeSpan.FromMinutes(45), "Pilot");
            Console.WriteLine(description);
            Episode episode = new Episode(10, 88.64, 9.78, description);
            Console.WriteLine(episode);

            // Assume that the number of rows in the text file is always at least 10. 
            // Assume a valid input file.
            string fileName = "shows.tv";
            string[] episodesInputs = File.ReadAllLines(fileName);
            Episode[] episodes = new Episode[episodesInputs.Length];
            for (int i = 0; i < episodes.Length; i++)
            {
                episodes[i] = TvUtilities.Parse(episodesInputs[i]);
            }

            Console.WriteLine("Episodes:");
            Console.WriteLine(string.Join<Episode>(Environment.NewLine, episodes));
            TvUtilities.Sort(episodes);
            Console.WriteLine("Sorted episodes:");
            string sortedEpisodesOutput = string.Join<Episode>(Environment.NewLine, episodes);
            Console.WriteLine(sortedEpisodesOutput);
            File.WriteAllText("sorted.tv", sortedEpisodesOutput);
        }
    }
}
