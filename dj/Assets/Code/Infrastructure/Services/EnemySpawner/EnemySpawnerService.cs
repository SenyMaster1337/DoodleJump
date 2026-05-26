using System;
using System.Collections.Generic;
using Code.Gameplay.Enemies;
using Code.Gameplay.Score;
using Code.Infrastructure.Factory.Game;
using Code.Infrastructure.SceneNameConstants;
using Code.Infrastructure.Services.LevelReset;
using Code.Infrastructure.Services.PlatformSpawner;
using Code.Infrastructure.Services.StaticData;
using Code.StaticData.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Infrastructure.Services.EnemySpawner
{
    public class EnemySpawnerService : IEnemySpawnerService, ILevelReset
    {
        private const float MinRoll = 0f;
        private const float MaxRoll = 1f;

        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IPlatformSpawnerService _platformSpawnerService;
        private readonly IScoreByHeightProvider _scoreByHeightProvider;

        private readonly Dictionary<EnemyType, Queue<IEnemy>> _pool = new();
        private readonly List<IEnemy> _active = new();

        private EnemySpawnData _data;
        private List<EnemyChanceData> _chances;

        private bool _isActive;
        private int _currentCount;

        public EnemySpawnerService(IGameFactory gameFactory, IStaticDataService staticDataService,
            IPlatformSpawnerService platformSpawnerService, IScoreByHeightProvider scoreByHeightProvider)
        {
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
            _platformSpawnerService = platformSpawnerService;
            _scoreByHeightProvider = scoreByHeightProvider;
        }

        public void Init()
        {
            _data = _staticDataService.GetGameStaticData(SceneNames.Main).EnemySpawnData;
            _chances = _data.EnemyChances;

            foreach (EnemyType type in Enum.GetValues(typeof(EnemyType)))
                _pool[type] = new Queue<IEnemy>();

            _scoreByHeightProvider.ScoreByHeight.ScoreChanged += OnActivateSpawnProcess;
        }

        public void Reset()
        {
            _active.Clear();

            foreach (var queue in _pool.Values)
                queue.Clear();
            
            _isActive = false;
            _currentCount = 0;
            
            _platformSpawnerService.PlatformSpawned -= OnEnemySpawned;
            _scoreByHeightProvider.ScoreByHeight.ScoreChanged -= OnActivateSpawnProcess;
        }

        private void ReturnToPool(IEnemy enemyDefault)
        {
            enemyDefault.GameObject.SetActive(false);
            _active.Remove(enemyDefault);

            EnemyType type = enemyDefault.Type;
            _pool[type].Enqueue(enemyDefault);
        }

        private void OnActivateSpawnProcess()
        {
            _currentCount++;

            if (_currentCount >= _data.ScoreToStartSpawn)
            {
                _platformSpawnerService.PlatformSpawned += OnEnemySpawned;
                _scoreByHeightProvider.ScoreByHeight.ScoreChanged -= OnActivateSpawnProcess;
                _isActive = true;
            }
        }

        private void OnEnemySpawned(Vector2 platformPosition)
        {
            if (_isActive == false)
                return;

            EnemyType type = GetRandomType();

            if (type == EnemyType.None)
                return;

            Vector2 spawnPosition = platformPosition + Vector2.up * _data.EnemyOffsetY;

            IEnemy enemyDefault = GetFromPool(type) ?? _gameFactory.CreateEnemy(type).GetComponent<IEnemy>();
            enemyDefault.SetCallbackReturnToPool(ReturnToPool);
            enemyDefault.GameObject.transform.position = spawnPosition;
            enemyDefault.GameObject.SetActive(true);
            _active.Add(enemyDefault);
        }

        private IEnemy GetFromPool(EnemyType type)
        {
            var queue = _pool[type];
            return queue.Count > 0 ? queue.Dequeue() : null;
        }

        private EnemyType GetRandomType()
        {
            float roll = Random.Range(MinRoll, MaxRoll);
            float cumulative = 0f;

            foreach (var ec in _chances)
            {
                cumulative += ec.Chance;

                if (roll < cumulative)
                    return ec.Type;
            }

            return EnemyType.None;
        }
    }
}