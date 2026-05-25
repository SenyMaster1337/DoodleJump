using Code.Core.Interfaces;
using Code.Core.LoadingCurtains;
using Code.Infrastructure.Factory.Game;
using Code.Infrastructure.Factory.UI;
using Code.Infrastructure.SceneLoaders;
using Code.Infrastructure.SceneNameConstants;
using Code.Infrastructure.Services.CameraFollowers;
using Code.Infrastructure.Services.CameraProviders;
using Code.Infrastructure.Services.EnemySpawner;
using Code.Infrastructure.Services.GoogleAdsShowers;
using Code.Infrastructure.Services.PlatformSpawner;
using Code.Infrastructure.Services.ScoreShowerServices;
using Code.Infrastructure.Services.StaticData;
using Code.StaticData.Game;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly ICameraProvider _cameraProvider;
        private readonly IPlatformSpawnerService _platformSpawnerService;
        private readonly IEnemySpawnerService _enemySpawnService;
        private readonly IUIFactory _uiFactory;
        private readonly IScoreShowerService _scoreShowerService;
        private readonly ILoadingCurtainProvider _loadingCurtainProvider;
        private readonly IGoogleAdsShowerService _adsShowerService;
        private readonly IStaticDataService _staticDataService;
        private readonly IBulletSpawnerService _bulletSpawnerService;

        public LoadLevelState(SceneLoader sceneLoader, IGameFactory gameFactory,
            ICameraProvider cameraProvider, IPlatformSpawnerService platformSpawnerService,
            IEnemySpawnerService enemySpawnService, IUIFactory uiFactory, IScoreShowerService scoreShowerService,
            ILoadingCurtainProvider loadingCurtainProvider, IGoogleAdsShowerService adsShowerService,
            IStaticDataService staticDataService, IBulletSpawnerService bulletSpawnerService)
        {
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _cameraProvider = cameraProvider;
            _platformSpawnerService = platformSpawnerService;
            _enemySpawnService = enemySpawnService;
            _uiFactory = uiFactory;
            _scoreShowerService = scoreShowerService;
            _loadingCurtainProvider = loadingCurtainProvider;
            _adsShowerService = adsShowerService;
            _staticDataService = staticDataService;
            _bulletSpawnerService = bulletSpawnerService;
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
            var data = _staticDataService.GetGameStaticData(SceneNames.Main);
            var player = _gameFactory.CreatePlayer();

            InitUIRoot();
            InitGameWorld();
            InitSpawners(player);
            InitCameraFollower(player, data);
            InitAdsShower();
            ClearPoolBulletSpawner();
            
            _loadingCurtainProvider.LoadingCurtain.Hide();
        }

        private void ClearPoolBulletSpawner()
            => _bulletSpawnerService.ClearPool();

        private void InitAdsShower()
            => _adsShowerService.ShowInterAd();

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
            _platformSpawnerService.Init();
            _enemySpawnService.Init();
            _platformSpawnerService.StartSpawn(player.transform.position.y);
        }

        private void InitUIRoot() =>
            _uiFactory.CreateUIRoot();
    }
}