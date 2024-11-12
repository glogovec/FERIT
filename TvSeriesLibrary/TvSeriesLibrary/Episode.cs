namespace TvSeriesLibrary
{
    public class Episode
    {
        private int viewersCount;
        private double totalScore;
        private double maxScore;

        public Episode() : this(0, 0.0, 0.0) { } //nice tip from AV 2

        public Episode(int viewersCount, double totalScore, double maxScore)
        {
            this.viewersCount = viewersCount;
            this.totalScore = totalScore;
            this.maxScore = maxScore;
        }

        public void AddView(double score)
        {
            viewersCount++;
            totalScore += score;
            if (score > maxScore)
                maxScore = score;
        }

        public double GetMaxScore() { return maxScore; }

        public double GetAverageScore() { return totalScore / viewersCount; }

        public int GetViewerCount() { return viewersCount; }


    }
}
