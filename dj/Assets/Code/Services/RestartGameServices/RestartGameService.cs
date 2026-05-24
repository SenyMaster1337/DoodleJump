using Code.Infrastructure.States;
using Code.Signals.RestartGameSignals;
using UnityEngine;
using Zenject;

namespace Code.Services.RestartGameServices
{
    public class RestartGameService : IInitializable, ILateDisposable, IRestartGameService
    {
        private const string MainSceneName = "Main";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SignalBus _signalBus;

        public RestartGameService(GameStateMachine gameStateMachine, SignalBus signalBus)
        {
            _gameStateMachine = gameStateMachine;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<RestartGameSignal>(OnGameRestarted);
        }

        public void LateDispose()
        {
            _signalBus.Unsubscribe<RestartGameSignal>(OnGameRestarted);
        }

        private void OnGameRestarted()
        {
            Time.timeScale = 1;
            _gameStateMachine.Enter<LoadLevelState, string>(MainSceneName);
        }
    }
}