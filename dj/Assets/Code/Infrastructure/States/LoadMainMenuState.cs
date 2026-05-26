using Code.Core.LoadingCurtains;
using Code.Infrastructure.SceneLoaders;

namespace Code.Infrastructure.States
{
    public class LoadMainMenuState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly ILoadingCurtainProvider _loadingCurtainProvider;

        public LoadMainMenuState(SceneLoader sceneLoader, ILoadingCurtainProvider loadingCurtainProvider)
        {
            _sceneLoader = sceneLoader;
            _loadingCurtainProvider = loadingCurtainProvider;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtainProvider.LoadingCurtain.Hide();
            _sceneLoader.Load(sceneName);
        }

        public void Exit()
        {
        }
    }
}