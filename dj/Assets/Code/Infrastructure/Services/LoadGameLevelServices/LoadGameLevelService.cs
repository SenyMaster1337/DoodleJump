using Code.Core.Signals;
using Code.Infrastructure.States;
using Zenject;

namespace Code.Infrastructure.Services.LoadGameLevelServices
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