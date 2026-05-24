using Code.Infrastructure.SceneLoaders;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private const string MenuSceneName = "Menu";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            if (SceneManager.GetActiveScene().name == Initial)
            {
                EnterLoadLevel();
            }
            else
            {
                _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
            }
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadMainMenuState, string>(MenuSceneName);
        }

        public void Exit()
        {
        }
    }
}