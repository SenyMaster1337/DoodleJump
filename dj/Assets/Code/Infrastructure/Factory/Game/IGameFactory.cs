using Code.StaticData.Enemy;
using Code.StaticData.Platform;
using UnityEngine;

namespace Code.Infrastructure.Factory.Game
{
    public interface IGameFactory
    {
        GameObject CreatePlayer();
        GameObject CreatePlatform(PlatformType type);
        GameObject CreateEnemy(EnemyType type);
    }
}