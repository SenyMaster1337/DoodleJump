using Code.Infrastructure.States;
using Code.Signals.StartGameSignals;
using Zenject;

namespace Code.Services.LoadGameLevelServices
{
    public class LoadGameLevelService : ILoadGameLevelService, IInitializable, ILateDisposable
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SignalBus _signalBus;

        public LoadGameLevelService(GameStateMachine gameStateMachine, SignalBus signalBus)
        {
            _gameStateMachine = gameStateMachine;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<StartGameSignal>(OnStartLoad);
        }

        public void LateDispose()
        {
            _signalBus.Unsubscribe<StartGameSignal>(OnStartLoad);
        }

        private void OnStartLoad()
        {
            _gameStateMachine.Enter<LoadProgressState>();
        }
    }
}