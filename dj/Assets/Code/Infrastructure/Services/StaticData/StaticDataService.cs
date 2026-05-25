using System.Collections.Generic;
using System.Linq;
using Code.StaticData.Enemy;
using Code.StaticData.Game;
using Code.StaticData.Platform;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService, IInitializable
    {
        private const string GameStaticDataPath = "StaticData/Game/GameStaticData";
        private const string PlatformStaticDataPath = "StaticData/Platforms";
        private const string EnemiesStaticDataPath = "StaticData/Enemies";

        private Dictionary<string, GameStaticData> _gameStaticData;
        private Dictionary<PlatformType, PlatformStaticData> _platformStaticData;
        private Dictionary<EnemyType, EnemyStaticData> _enemyStaticData;

        public void Initialize()
        {
            Load();
        }

        private void Load()
        {
            _gameStaticData = Resources
                .LoadAll<GameStaticData>(GameStaticDataPath)
                .ToDictionary(x => x.SceneKey, x => x);

            _platformStaticData = Resources
                .LoadAll<PlatformStaticData>(PlatformStaticDataPath)
                .ToDictionary(x => x.PlatformType, x => x);

            _enemyStaticData = Resources
                .LoadAll<EnemyStaticData>(EnemiesStaticDataPath)
                .ToDictionary(x => x.Type, x => x);
        }

        public GameStaticData GetGameStaticData(string sceneKey) =>
            _gameStaticData.TryGetValue(sceneKey, out GameStaticData staticData)
                ? staticData
                : null;

        public PlatformData GetPlatformData(PlatformType platformType) =>
            _platformStaticData.TryGetValue(platformType, out PlatformStaticData staticData)
                ? staticData.PlatformData
                : null;

        public EnemyData GetEnemyData(EnemyType enemyType) =>
            _enemyStaticData.TryGetValue(enemyType, out EnemyStaticData staticData)
                ? staticData.EnemyData
                : null;
    }
}