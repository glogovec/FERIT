namespace TvSeriesLibrary
{
    public class Episode
    {
        private int viewersCount;
        private double totalScore;
        private double maxScore;
        public Description Description { get; private set; }

        public Episode() : this(0, 0.0, 0.0, null) { } 

        public Episode(int viewersCount, double totalScore, double maxScore, Description description)
        {
            this.viewersCount = viewersCount;
            this.totalScore = totalScore;
            this.maxScore = maxScore;
            Description = description;
        }

        public void AddView(double score)
        {
            viewersCount++;
            totalScore += score;
            if (score > maxScore)
                maxScore = score;
        }

        public double GetMaxScore() { return maxScore; }

        public double GetAverageScore()
        {
            return viewersCount == 0 ? 0.0 : totalScore / viewersCount;
        }

        public override string ToString()
        {
            return $"Viewer count: {viewersCount}, Total score: {totalScore:F2}, Max score: {maxScore}, " + Description.ToString();
        }
        public int GetViewerCount() { return viewersCount; }

        public static bool operator >(Episode lhs, Episode rhs)
        {
            return lhs.GetAverageScore() > rhs.GetAverageScore();
        }

        public static bool operator <(Episode lhs, Episode rhs)
        {
            return rhs > lhs;
        }
    }
}
