using Code.Gameplay.Enemies;

namespace Code.Services.EnemySpawner
{
    public interface IEnemySpawnerService
    {
        void Init();
        void ReturnToPool(IEnemy enemyDefault);
    }
}