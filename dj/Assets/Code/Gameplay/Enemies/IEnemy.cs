using System;
using Code.StaticData.Enemy;
using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public interface IEnemy
    {
        GameObject GameObject { get; }
        EnemyType Type { get; }
        void InitType(EnemyType type);
        void SetCallbackReturnToPool(Action<IEnemy> returnCallback);
        void Die();
    }
}