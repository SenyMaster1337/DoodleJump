using Code.Gameplay.PlayerComponents;
using Code.Infrastructure.Factory.Game;
using Code.Infrastructure.Factory.UI;
using Code.Infrastructure.SceneLoaders;
using Code.Logic.LoadingCurtains;
using Code.Services.CamaraFollowers;
using Code.Services.CameraProviders;
using Code.Services.EnemySpawner;
using Code.Services.GoogleAdsShowers;
using Code.Services.PlatformSpawner;
using Code.Services.PlayerDeathServices;
using Code.Services.ScoreShowerServices;
using Code.Services.StaticData;
using Code.StaticData.Game;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string EmptySceneName = "Empty";
        private const string MainSceneName = "Main";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly ICameraProvider _cameraProvider;
        private readonly IPlatformSpawnService _platformSpawnService;
        private readonly IEnemySpawnerService _enemySpawnService;
        private readonly IUIFactory _uiFactory;
        private readonly IPlayerDeathHandlerServices _playerDeathHandlerServices;
        private readonly IScoreShowerService _scoreShowerService;
        private readonly ILoadingCurtainProvider _loadingCurtainProvider;
        private readonly IGoogleAdsShowerService _adsShowerService;
        private readonly IStaticDataService _staticDataService;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory,
            ICameraProvider cameraProvider, IPlatformSpawnService platformSpawnService,
            IEnemySpawnerService enemySpawnService, IUIFactory uiFactory,
            IPlayerDeathHandlerServices playerDeathHandlerServices, IScoreShowerService scoreShowerService,
            ILoadingCurtainProvider loadingCurtainProvider, IGoogleAdsShowerService adsShowerService,
            IStaticDataService staticDataService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _cameraProvider = cameraProvider;
            _platformSpawnService = platformSpawnService;
            _enemySpawnService = enemySpawnService;
            _uiFactory = uiFactory;
            _playerDeathHandlerServices = playerDeathHandlerServices;
            _scoreShowerService = scoreShowerService;
            _loadingCurtainProvider = loadingCurtainProvider;
            _adsShowerService = adsShowerService;
            _staticDataService = staticDataService;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtainProvider.LoadingCurtain.Show();
            _sceneLoader.Load(EmptySceneName, () => _sceneLoader.Load(sceneName, OnLoaded));
        }

        public void Exit()
        {
            _loadingCurtainProvider.LoadingCurtain.Hide();
        }

        private void OnLoaded()
        {
            var data = _staticDataService.GetGameStaticData(MainSceneName);
            var player = _gameFactory.CreatePlayer();

            InitUIRoot();
            InitGameWorld();
            InitSpawners(player);
            InitCameraFollower(player, data);
            InitPlayerDeathHandler(player);
            InitAdsShower();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InitAdsShower()
            => _adsShowerService.ShowInterAd();

        private void InitPlayerDeathHandler(GameObject player)
            => _playerDeathHandlerServices.SetPlayer(player.GetComponent<Player>());

        private void InitCameraFollower(GameObject player, GameStaticData data)
        {
            _cameraProvider.MainCamera.GetComponent<CameraFollower>()
                .Init(player.transform, data.CameraSettingsData.SmoothTimeFollowToPlayer);
        }

        private void InitGameWorld()
        {
            _uiFactory.CreateHud();
            _scoreShowerService.Init();
        }

        private void InitSpawners(GameObject player)
        {
            _platformSpawnService.Init();
            _enemySpawnService.Init();
            _platformSpawnService.StartSpawn(player.transform.position.y);
        }

        private void InitUIRoot() =>
            _uiFactory.CreateUIRoot();
    }
}