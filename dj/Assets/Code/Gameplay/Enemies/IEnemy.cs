using System;
using Code.StaticData.Enemy;
using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public interface IEnemy
    {
        Transform Transform { get; }
        GameObject GameObject { get; }
        public EnemyType Type { get; }
        public void Init(EnemyType type, EnemySettingsData data);
        public void SetCallbackReturnToPool(Action<IEnemy> returnCallback);
        public void Die();
    }
}