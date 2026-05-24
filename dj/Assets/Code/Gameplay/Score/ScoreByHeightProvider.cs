namespace Code.Gameplay.Score
{
    public class ScoreByHeightProvider : IScoreByHeightProvider
    {
        public ScoreByHeight ScoreByHeight { get; private set; }

        public void SetScoreByHeight(ScoreByHeight scoreByHeight) 
            => ScoreByHeight = scoreByHeight;
    }
}