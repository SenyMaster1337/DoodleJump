namespace Code.Gameplay.Score
{
    public interface IScoreByHeightProvider
    {
        ScoreByHeight ScoreByHeight { get; }
        void SetScoreByHeight(ScoreByHeight scoreByHeight);
    }
}