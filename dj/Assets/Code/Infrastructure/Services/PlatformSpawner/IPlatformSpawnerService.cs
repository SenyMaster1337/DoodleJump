using System;
using UnityEngine;

namespace Code.Infrastructure.Services.PlatformSpawner
{
    public interface IPlatformSpawnerService
    {
        void Init();
        void StartSpawn();
        event Action<Vector2> PlatformSpawned;
    }
}