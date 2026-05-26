using Code.Core.Interfaces;
using Code.Infrastructure.Services.EnemySpawner;
using Code.Infrastructure.Services.PlatformSpawner;

namespace Code.Infrastructure.Services.Setups.Spawners
{
    public class SpawnersSetup : ISpawnersSetup
    {
        private readonly IPlatformSpawnerService _platformSpawner;
        private readonly IEnemySpawnerService _enemySpawner;
        private readonly IBulletSpawnerService _bulletSpawner;

        public SpawnersSetup(IPlatformSpawnerService platformSpawner, IEnemySpawnerService enemySpawner,
            IBulletSpawnerService bulletSpawner)
        {
            _platformSpawner = platformSpawner;
            _enemySpawner = enemySpawner;
            _bulletSpawner = bulletSpawner;
        }

        public void Init()
        {
            _platformSpawner.Init();
            _enemySpawner.Init();
            _platformSpawner.StartSpawn();
            _bulletSpawner.ClearPool();
        }
    }
}