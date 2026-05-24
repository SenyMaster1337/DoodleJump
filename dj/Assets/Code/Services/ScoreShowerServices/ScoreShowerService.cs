using Code.Gameplay.Score;
using Code.Infrastructure.Factory.UI;
using Code.Services.PersistentProgress;
using Code.UI.ScoreShowers;
using Zenject;

namespace Code.Services.ScoreShowerServices
{
    public class ScoreShowerService : IScoreShowerService, ILateDisposable
    {
        private readonly IUIFactory _uiFactory;
        private readonly IScoreByHeightProvider _scoreByHeightProvider;
        private readonly IPersistentProgressService _progressService;

        private ScoreShowerView _scoreShowerView;

        public ScoreShowerService(IUIFactory uiFactory, IScoreByHeightProvider scoreByHeightProvider,
            IPersistentProgressService progressService)
        {
            _uiFactory = uiFactory;
            _scoreByHeightProvider = scoreByHeightProvider;
            _progressService = progressService;
        }

        public void Init()
        {
            _scoreShowerView = _uiFactory.GetScoreShowerView();
            _scoreByHeightProvider.ScoreByHeight.ScoreChanged += OnUpdateScore;
            
            _scoreShowerView.UpdateBestScore(_progressService.Progress.WorldData.ScoreData.BestScoreValue);
        }

        public void LateDispose() 
            => _scoreByHeightProvider.ScoreByHeight.ScoreChanged -= OnUpdateScore;

        private void OnUpdateScore()
        {
            int currentScoreValue = _scoreByHeightProvider.ScoreByHeight.ScoreValue;
            int bestScoreValue = _progressService.Progress.WorldData.ScoreData.BestScoreValue;

            _scoreShowerView.UpdateCurrentScore(currentScoreValue);

            if (currentScoreValue >= bestScoreValue)
            {
                _progressService.Progress.WorldData.ScoreData.BestScoreValue = currentScoreValue;
                _scoreShowerView.UpdateBestScore(currentScoreValue);
            }
        }
    }
}