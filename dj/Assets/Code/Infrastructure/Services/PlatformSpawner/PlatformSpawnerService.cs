using System;
using System.Collections.Generic;
using Code.Gameplay.Platforms;
using Code.Gameplay.Score;
using Code.Infrastructure.Factory.Game;
using Code.Infrastructure.SceneNameConstants;
using Code.Infrastructure.Services.StaticData;
using Code.StaticData.Platform;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Infrastructure.Services.PlatformSpawner
{
    public class PlatformSpawnerService : IPlatformSpawnerService
    {
        private const float MinRoll = 0f;
        private const float MaxRoll = 1f;
        private const float MaxChance = 1f;
        private const float RandomOffsetMultiplier = 0.3f;
        private const float ZeroPositionZ = 0;

        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IScoreByHeightProvider _scoreByHeightProvider;

        private Dictionary<PlatformType, Queue<IPlatform>> _pool = new();
        private List<IPlatform> _active = new();
        private HashSet<int> _occupiedColumns = new();

        private PlatformsSpawnData _platformsSpawnData;
        private List<PlatformChanceData> _chances;
        private float _currentRowY;
        private bool _isEmptyChanceActive;
        private int _currentCount;

        public event Action<Vector2> PlatformSpawned;

        public PlatformSpawnerService(IGameFactory gameFactory, IStaticDataService staticDataService,
            IScoreByHeightProvider scoreByHeightProvider)
        {
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
            _scoreByHeightProvider = scoreByHeightProvider;
        }

        public void Init()
        {
            _scoreByHeightProvider.ScoreByHeight.ScoreChanged -= OnActivateSpawnEmptyPlatformChance;
            _scoreByHeightProvider.ScoreByHeight.ScoreChanged += OnActivateSpawnEmptyPlatformChance;

            _occupiedColumns.Clear();
            _active.Clear();

            foreach (var queue in _pool.Values)
                queue.Clear();

            _currentCount = 0;
            _currentRowY = 0;
            _isEmptyChanceActive = false;

            _platformsSpawnData = _staticDataService.GetGameStaticData(SceneNames.Main).PlatformsSpawnData;
            _chances = _platformsSpawnData.PlatformChances;

            foreach (PlatformType type in Enum.GetValues(typeof(PlatformType)))
                _pool[type] = new Queue<IPlatform>();
        }

        public void StartSpawn(float startY)
        {
            _occupiedColumns.Clear();
            _currentRowY = startY + _platformsSpawnData.StepY;

            PlaceFirstPlatform();

            for (int i = 0; i < _platformsSpawnData.StartCount; i++)
                SpawnPlatform();
        }

        private void PlaceFirstPlatform()
            => PlacePlatform(PlatformType.Default,
                _staticDataService.GetGameStaticData(SceneNames.Main).StartSpawnPosition);

        public void ReturnToPool(IPlatform platform)
        {
            platform.GameObject.SetActive(false);
            _active.Remove(platform);
            _pool[platform.Type].Enqueue(platform);

            while (_active.Count < _platformsSpawnData.StartCount)
                SpawnPlatform();
        }

        private void OnActivateSpawnEmptyPlatformChance()
        {
            _currentCount++;

            if (_currentCount >= _platformsSpawnData.ScoreCountToComplication)
            {
                _scoreByHeightProvider.ScoreByHeight.ScoreChanged -= OnActivateSpawnEmptyPlatformChance;
                _isEmptyChanceActive = true;
            }
        }

        private void SpawnPlatform()
        {
            PlatformType type = GetRandomType();

            int column = GetFreeColumn();

            if (column < 0)
            {
                _occupiedColumns.Clear();
                _currentRowY += _platformsSpawnData.StepY;
                column = GetFreeColumn();
            }

            _occupiedColumns.Add(column);

            if (type == PlatformType.None)
                return;

            float x = GetColumnX(column);
            float y = _currentRowY;
            Vector3 position = new Vector3(x, y, ZeroPositionZ);

            PlacePlatform(type, position);
        }

        private void PlacePlatform(PlatformType type, Vector3 position)
        {
            IPlatform platform = GetFromPool(type) ?? _gameFactory.CreatePlatform(type).GetComponent<IPlatform>();
            platform.SetCallbackReturnToPool(ReturnToPool);
            platform.Transform.position = position;
            platform.GameObject.SetActive(true);
            _active.Add(platform);
            PlatformSpawned?.Invoke(platform.Transform.position);
        }

        private int GetFreeColumn()
        {
            for (int i = 0; i < _platformsSpawnData.ColumnsCount; i++)
                if (_occupiedColumns.Contains(i) == false)
                    return i;

            return -1;
        }

        private float GetColumnX(int column)
        {
            float totalWidth = (_platformsSpawnData.ColumnsCount - 1) * _platformsSpawnData.ColumnSpacing;
            float startX = -totalWidth / 2f;
            float baseX = startX + column * _platformsSpawnData.ColumnSpacing;
            float maxOffset = _platformsSpawnData.ColumnSpacing * RandomOffsetMultiplier;
            float randomOffset = Random.Range(-maxOffset, maxOffset);

            return baseX + randomOffset;
        }

        private IPlatform GetFromPool(PlatformType type)
            => _pool[type].Count > 0 ? _pool[type].Dequeue() : null;

        private PlatformType GetRandomType()
        {
            float roll = Random.Range(MinRoll, MaxRoll);

            if (_isEmptyChanceActive)
            {
                if (roll <= _platformsSpawnData.EmptyChance)
                    return PlatformType.None;
            }

            float remaining = (roll - _platformsSpawnData.EmptyChance) / (MaxChance - _platformsSpawnData.EmptyChance);
            float cumulative = 0f;
            float totalChance = 0f;

            foreach (var pc in _chances)
                totalChance += pc.Chance;

            if (totalChance <= 0f) return PlatformType.Default;

            foreach (var pc in _chances)
            {
                cumulative += pc.Chance / totalChance;

                if (remaining < cumulative)
                    return pc.Type;
            }

            return PlatformType.Default;
        }
    }
}