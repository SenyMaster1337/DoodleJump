using System;
using Code.StaticData.Enemy;
using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public class EnemyHorizontalMover : MonoBehaviour, IEnemy
    {
        public Transform Transform { get; private set; }
        public GameObject GameObject { get; private set; }
        public EnemyType Type { get; private set; }

        private float _speed;
        private float _range;
        private float _startX;

        private Action<IEnemy> _dead;

        private void Awake()
        {
            Transform = transform;
            GameObject = gameObject;

            _startX = transform.position.x;
        }

        private void Update()
        {
            float x = _startX + Mathf.PingPong(Time.time * _speed, _range * 2) - _range;

            transform.position =
                new Vector3(x, transform.position.y, transform.position.z);
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