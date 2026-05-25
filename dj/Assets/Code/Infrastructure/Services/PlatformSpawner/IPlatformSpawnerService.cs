using System;
using Code.Gameplay.Platforms;
using UnityEngine;

namespace Code.Infrastructure.Services.PlatformSpawner
{
    public interface IPlatformSpawnerService
    {
        void Init();
        void StartSpawn(float startY);
        void ReturnToPool(IPlatform platform);
        event Action<Vector2> PlatformSpawned;
    }
}