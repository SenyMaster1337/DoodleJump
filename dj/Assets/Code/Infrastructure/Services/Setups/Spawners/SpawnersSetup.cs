using Code.Infrastructure.Services.EnemySpawner;
using Code.Infrastructure.Services.PlatformSpawner;

namespace Code.Infrastructure.Services.Setups.Spawners
{
    public class SpawnersSetup : ISpawnersSetup
    {
        private readonly IPlatformSpawnerService _platformSpawner;
        private readonly IEnemySpawnerService _enemySpawner;

        public SpawnersSetup(IPlatformSpawnerService platformSpawner, IEnemySpawnerService enemySpawner)
        {
            _platformSpawner = platformSpawner;
            _enemySpawner = enemySpawner;
        }

        public void Init()
        {
            _platformSpawner.Init();
            _enemySpawner.Init();
            _platformSpawner.StartSpawn();
        }
    }
}