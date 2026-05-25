using Code.Gameplay.Enemies;
using Code.Gameplay.Platforms;
using Code.Gameplay.PlayerComponents;
using Code.Gameplay.PlayerComponents.PlayerJumpers;
using Code.Gameplay.PlayerComponents.PlayerMovers;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Services.LoseServices;
using Code.Infrastructure.Services.StaticData;
using Code.StaticData.Enemy;
using Code.StaticData.Platform;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory.Game
{
    public class GameFactory : IGameFactory
    {
        private const string MainSceneName = "Main";

        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly ILoseService _loseService;

        private IInstantiator _instantiator;

        public GameFactory(IAssetProvider assetProvider, IStaticDataService staticDataService, ILoseService loseService)
        {
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
            _loseService = loseService;
        }

        public void SetSceneInstantiator(IInstantiator instantiator)
            => _instantiator = instantiator;

        public GameObject CreatePlayer()
        {
            var playerPrefab = _assetProvider.Load(AssetPath.PlayerPath);

            var gameStaticData = _staticDataService.GetGameStaticData(MainSceneName);
            var playerSettingsData = gameStaticData.PlayerSettingsData;

            GameObject player = _instantiator.InstantiatePrefab(playerPrefab, gameStaticData.StartSpawnPosition,
                Quaternion.identity, null);

            player.GetComponent<PlayerMover>().Init(playerSettingsData.MoveSpeed);
            player.GetComponent<PlayerJumper>().Init(playerSettingsData.JumpForce);

            player.GetComponent<Player>().Dead += _loseService.StartLoseProcess;

            return player;
        }

        public GameObject CreateEnemy(EnemyType type)
        {
            var enemyData = _staticDataService.GetEnemyData(type);
            GameObject enemy = _instantiator.InstantiatePrefab(enemyData.EnemyPrefab);

            var enemyComponent = enemy.GetComponent<IEnemy>();
            enemyComponent.InitType(type);

            if (enemyComponent is IConfigurableEnemy configurator)
                configurator.InitSettings(_staticDataService.GetGameStaticData(MainSceneName).EnemySettingsData);

            return enemy;
        }

        public GameObject CreatePlatform(PlatformType type)
        {
            var platformData = _staticDataService.GetPlatformData(type);
            GameObject platform = _instantiator.InstantiatePrefab(platformData.PlatformPrefab);

            var platformComponent = platform.GetComponent<IPlatform>();
            platformComponent.InitType(type);

            if (platformComponent is IConfigurablePlatform configurable)
                configurable.InitSettings(_staticDataService.GetGameStaticData(MainSceneName).PlatformSettingsData);

            return platform;
        }
    }
}