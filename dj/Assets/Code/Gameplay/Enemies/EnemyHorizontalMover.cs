using System;
using Code.Gameplay.Common;
using Code.StaticData.Enemy;
using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public class EnemyHorizontalMover : HorizontalPingPongMover, IEnemy
    {
        public EnemyType Type { get; private set; }
        public Transform Transform { get; private set; }
        public GameObject GameObject { get; private set; }

        private Action<IEnemy> _dead;

        private void Awake()
        {
            Transform = transform;
            GameObject = gameObject;
        }

        public void Init(EnemyType type, EnemySettingsData data)
        {
            Type = type;
            _speed = data.EnemyHorizontalMoverData.Speed;
            _range = data.EnemyHorizontalMoverData.RangeHorizontalMoving;
        }

        public void SetCallbackReturnToPool(Action<IEnemy> returnCallback)
            => _dead = returnCallback;

        public void Die()
            => _dead?.Invoke(this);
    }
}