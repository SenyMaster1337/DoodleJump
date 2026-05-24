using Code.StaticData.Enemy;
using Code.StaticData.Platform;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory.Game
{
    public interface IGameFactory
    {
        GameObject CreatePlayer();
        GameObject CreatePlatform(PlatformType type);
        GameObject CreateEnemy(EnemyType type);
        void SetSceneInstantiator(IInstantiator instantiator);
    }
}