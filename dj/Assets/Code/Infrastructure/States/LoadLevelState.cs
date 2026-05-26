using Code.Core.LoadingCurtains;
using Code.Infrastructure.SceneLoaders;
using Code.Infrastructure.SceneNameConstants;
using Code.Infrastructure.Services.Setups.Ads;
using Code.Infrastructure.Services.Setups.Camera;
using Code.Infrastructure.Services.Setups.Player;
using Code.Infrastructure.Services.Setups.Spawners;
using Code.Infrastructure.Services.Setups.UI;

namespace Code.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly ILoadingCurtainProvider _loadingCurtainProvider;
        private readonly ISpawnersSetup _spawnersSetup;
        private readonly IUISetup _uiSetup;
        private readonly IAdsSetup _adsSetup;
        private readonly IPlayerSetup _playerSetup;
        private readonly ICameraSetup _cameraSetup;

        public LoadLevelState(SceneLoader sceneLoader, ILoadingCurtainProvider loadingCurtainProvider,
            ISpawnersSetup spawnersSetup, IUISetup uiSetup, IAdsSetup adsSetup, IPlayerSetup playerSetup,
            ICameraSetup cameraSetup)
        {
            _sceneLoader = sceneLoader;
            _loadingCurtainProvider = loadingCurtainProvider;
            _spawnersSetup = spawnersSetup;
            _uiSetup = uiSetup;
            _adsSetup = adsSetup;
            _playerSetup = playerSetup;
            _cameraSetup = cameraSetup;
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
            _playerSetup.Init();
            _uiSetup.Init();
            _cameraSetup.Init();
            _spawnersSetup.Init();
            _adsSetup.Init();

            _loadingCurtainProvider.LoadingCurtain.Hide();
        }
    }
}