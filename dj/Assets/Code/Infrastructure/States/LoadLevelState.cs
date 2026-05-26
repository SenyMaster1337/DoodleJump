using Code.Core.LoadingCurtains;
using Code.Infrastructure.SceneLoaders;
using Code.Infrastructure.SceneNameConstants;
using Code.Infrastructure.Services.Setups.Ads;

namespace Code.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly ILoadingCurtainProvider _loadingCurtainProvider;
        private readonly IAdsSetup _adsSetup;

        public LoadLevelState(SceneLoader sceneLoader, ILoadingCurtainProvider loadingCurtainProvider,
            IAdsSetup adsSetup)
        {
            _sceneLoader = sceneLoader;
            _loadingCurtainProvider = loadingCurtainProvider;
            _adsSetup = adsSetup;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtainProvider.LoadingCurtain.Show();
            _sceneLoader.Load(SceneNames.Empty, () => _sceneLoader.Load(sceneName, OnLoaded));
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            _adsSetup.Init();

            _loadingCurtainProvider.LoadingCurtain.Hide();
        }
    }
}