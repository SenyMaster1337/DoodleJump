using Code.Data;
using Code.Infrastructure.Services.PersistentProgress;
using Code.Infrastructure.Services.SaveLoad;

namespace Code.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private const string MainSceneName = "Main";
        private const int ZeroScore = 0;

        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService,
            ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();

            _gameStateMachine.Enter<LoadLevelState, string>(MainSceneName);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress =
                _saveLoadService.LoadProgress()
                ?? InitNewProgress();
        }

        private PlayerProgress InitNewProgress()
        {
            var progress = new PlayerProgress();
            progress.WorldData.ScoreData.BestScoreValue = ZeroScore;

            return progress;
        }
    }
}