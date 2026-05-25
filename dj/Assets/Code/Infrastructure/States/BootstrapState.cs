using Code.Infrastructure.SceneLoaders;
using Code.Infrastructure.SceneNameConstants;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            if (SceneManager.GetActiveScene().name == SceneNames.Initial)
            {
                EnterLoadLevel();
            }
            else
            {
                _sceneLoader.Load(SceneNames.Initial, onLoaded: EnterLoadLevel);
            }
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadMainMenuState, string>(SceneNames.Menu);
        }

        public void Exit()
        {
        }
    }
}