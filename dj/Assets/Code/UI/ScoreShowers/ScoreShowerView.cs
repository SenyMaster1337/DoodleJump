using UnityEngine;

namespace Code.UI.ScoreShowers
{
    public class ScoreShowerView : MonoBehaviour
    {
        private CurrentScoreText _currentScoreText;
        private BestScoreText _bestScoreText;

        private void Awake()
        {
            _currentScoreText = GetComponentInChildren<CurrentScoreText>();
            _bestScoreText = GetComponentInChildren<BestScoreText>();
        }

        public void UpdateCurrentScore(int score) 
            => _currentScoreText.SetValue(score);

        public void UpdateBestScore(int score) 
            => _bestScoreText.SetValue(score);
    }
}