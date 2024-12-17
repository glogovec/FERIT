using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TvSeriesLibrary
{
    public class Season
    {
        Episode[] episodes;
        public int SeasonNumber { get; private set; }
        public int Length => episodes.Length;
        
        public Season(int seasonNumber, Episode[] episodes)
        {
            SeasonNumber = seasonNumber;
            this.episodes = episodes;
        }

        public Episode this[int episodeIndex]
        {
            get { return episodes[episodeIndex]; }
            set { episodes[episodeIndex] = value; }
        }

        public int GetTotalViewers()
        {
            int totalViewers = 0;

            foreach(Episode episode in episodes)
            {
                totalViewers += episode.GetViewerCount();
            }
            return totalViewers;
        }

        public TimeSpan TotalDuration()
        {
            TimeSpan totalDuration = TimeSpan.Zero;
            foreach(Episode episode in episodes)
            {
                totalDuration += episode.Description.Duration;
            }
            return totalDuration;
        }
        public DateTime GetBingeEnd()
        {
            return DateTime.Now.Add(TotalDuration());
        }

        public override string ToString()
        {   
            StringBuilder builder = new StringBuilder();
            string breakLine = "=================================================";
            builder.AppendLine($"Season {SeasonNumber}:").AppendLine(breakLine);

            foreach(Episode episode in episodes)
            {
                builder.AppendLine(episode.ToString());
            }

            builder.AppendLine(breakLine);
            builder.AppendLine($"Total viewers: {GetTotalViewers()}").AppendLine($"Total duration: {TotalDuration()}");
            builder.AppendLine(breakLine);

            return builder.ToString();
        }
    }
}
