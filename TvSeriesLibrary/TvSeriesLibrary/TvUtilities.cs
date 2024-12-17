using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvSeriesLibrary
{
    public static class TvUtilities
    {
        public static double GenerateRandomScore()
        {
            Random random = new Random();
            return Math.Round(random.NextDouble() * 10, 2);
        }
        public static double GenerateRandomScore(Random randomGenerator)
        {
            return Math.Round(randomGenerator.NextDouble() * 10, 2); // NextDouble() generates doubles from 0.00 do 1.00 so we have to multiply it by 10 
        }

        public static Episode Parse(string episodeInfo)
        {
            char splitToken = ',';
            string[] episodeParts = episodeInfo.Split(splitToken);

            int viewersCount = int.Parse(episodeParts[0]);
            double totalScore = double.Parse(episodeParts[1]);
            double maxScore = double.Parse(episodeParts[2]);
            int episodeNumber = int.Parse(episodeParts[3]);
            TimeSpan duration = TimeSpan.FromMinutes(double.Parse(episodeParts[4]));
            string title = episodeParts[5];

            Description description = new Description(episodeNumber, duration, title);
            return new Episode(viewersCount, totalScore, maxScore, description);
        }
        public static void Sort(Episode[] episodes)
        {
            //Array.Sort(episodes, (lhs, rhs) => rhs.GetAverageScore().CompareTo(lhs.GetAverageScore()));

            Episode tempEpisode;

            for (int i = 0; i < episodes.Length - 1; i++) 
            {
                for (int j = i + 1; j < episodes.Length; j++) 
                {
                    if (episodes[i].GetAverageScore() < episodes[j].GetAverageScore())
                    {
                        tempEpisode = episodes[i];
                        episodes[i] = episodes[j];
                        episodes[j] = tempEpisode;
                    }
                }
            }
        }

        public static Episode[] LoadEpisodesFromFile(string path)
        {
            string[] episodesInputs = File.ReadAllLines(path);
            Episode[] episodes = new Episode[episodesInputs.Length];
            
            for (int i = 0; i < episodes.Length; i++)
            {
                episodes[i] = TvUtilities.Parse(episodesInputs[i]);
            }

            return episodes;
        }
    }
}
