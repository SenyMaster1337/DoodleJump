using Code.Core.Signals;
using Code.Infrastructure.SceneNameConstants;
using Code.Infrastructure.Services.GameTime;
using Code.Infrastructure.States;
using Zenject;

namespace Code.Infrastructure.Services.RestartGameServices
{
    public class RestartGameService : IInitializable, ILateDisposable, IRestartGameService
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SignalBus _signalBus;
        private readonly IGameTimeService _gameTimeService;

        public RestartGameService(GameStateMachine gameStateMachine, SignalBus signalBus,
            IGameTimeService gameTimeService)
        {
            _gameStateMachine = gameStateMachine;
            _signalBus = signalBus;
            _gameTimeService = gameTimeService;
        }

        public void Initialize()
            => _signalBus.Subscribe<RestartGameSignal>(OnGameRestarted);

        public void LateDispose()
            => _signalBus.Unsubscribe<RestartGameSignal>(OnGameRestarted);

        private void OnGameRestarted()
        {
            _gameTimeService.Resume();
            _gameStateMachine.Enter<LoadLevelState, string>(SceneNames.Main);
        }
    }
}