using Code.Core.LoadingCurtains;
using Code.Infrastructure.Factory.UI;
using Code.Infrastructure.SceneLoaders;

namespace Code.Infrastructure.States
{
    public class LoadMainMenuState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly ILoadingCurtainProvider _loadingCurtainProvider;

        public LoadMainMenuState(SceneLoader sceneLoader, IUIFactory uiFactory,
            ILoadingCurtainProvider loadingCurtainProvider)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _loadingCurtainProvider = loadingCurtainProvider;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtainProvider.LoadingCurtain.Hide();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            InitUIRoot();
            InitGameWorld();
        }

        private void InitUIRoot()
            => _uiFactory.CreateUIRoot();

        private void InitGameWorld()
        {
            _uiFactory.CreateControlsInstruction();
            _uiFactory.CreateStartButton();
        }
    }
}