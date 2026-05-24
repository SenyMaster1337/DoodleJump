using Code.Infrastructure.Factory.Game;
using Code.Infrastructure.Factory.UI;
using Code.Infrastructure.SceneLoaders;
using Code.Logic.LoadingCurtains;
using Code.Services.CameraProviders;
using Code.Services.EnemySpawner;
using Code.Services.PlatformSpawner;

namespace Code.Infrastructure.States
{
    public class LoadMainMenuState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly ICameraProvider _cameraProvider;
        private readonly IPlatformSpawnService _platformSpawnService;
        private readonly IEnemySpawnerService _enemySpawnService;
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