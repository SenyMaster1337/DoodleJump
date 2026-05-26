using System;
using Code.StaticData.Enemy;
using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public class EnemyDefault : MonoBehaviour, IEnemy
    {
        public GameObject GameObject { get; private set; }
        public EnemyType Type { get; private set; }

        private Action<IEnemy> _dead;

        private void Awake() 
            => GameObject = gameObject;

        public void InitType(EnemyType type)
            => Type = type;

        public void SetCallbackReturnToPool(Action<IEnemy> returnCallback)
            => _dead = returnCallback;

        public void Die()
            => _dead?.Invoke(this);
    }
}