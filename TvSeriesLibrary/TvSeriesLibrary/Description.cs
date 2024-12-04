using System;

namespace TvSeriesLibrary
{
    public class Description
    {
        public int EpisodeNumber { get; private set; }
        public TimeSpan Duration { get; private set; }
        public string Title { get; private set; }

        public Description(int episodeNumber, TimeSpan duration, string title)
        {
            EpisodeNumber = episodeNumber;
            Duration = duration;
            Title = title;
        }

        public override string ToString()
        {
            return $"Episode: {EpisodeNumber}, Duration: {Duration}, Title: {Title}";
        }
    }
}
