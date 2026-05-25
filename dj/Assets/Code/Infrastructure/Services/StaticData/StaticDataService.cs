using System;
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

        public GameStaticData GetGameStaticData(string sceneKey)
        {
            if (_gameStaticData.TryGetValue(sceneKey, out GameStaticData staticData))
                return staticData;

            throw new InvalidOperationException(
                $"GameStaticData for scene key '{sceneKey}' not found. Check Resources/{GameStaticDataPath}.");
        }

        public PlatformData GetPlatformData(PlatformType platformType)
        {
            if (_platformStaticData.TryGetValue(platformType, out PlatformStaticData staticData))
                return staticData.PlatformData;

            throw new InvalidOperationException(
                $"PlatformData for type '{platformType}' not found. Check Resources/{PlatformStaticDataPath}.");
        }

        public EnemyData GetEnemyData(EnemyType enemyType)
        {
            if (_enemyStaticData.TryGetValue(enemyType, out EnemyStaticData staticData))
                return staticData.EnemyData;

            throw new InvalidOperationException(
                $"EnemyData for type '{enemyType}' not found. Check Resources/{EnemiesStaticDataPath}.");
        }
    }
}