using System;
using Code.Gameplay.Enemies;
using UnityEngine;

namespace Code.Gameplay.Bullets
{
    [RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private float _speed;
        private float _lifetime;
        private float _timer;

        private Action<Bullet> _hited;

        private void Awake()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;

            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.isKinematic = true;
            _rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }

        private void OnEnable() 
            => _timer = 0f;

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _lifetime)
                _hited?.Invoke(this);
        }

        private void FixedUpdate() 
            => _rigidbody2D.velocity = Vector2.up * _speed;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IEnemy>(out var enemy))
            {
                _hited?.Invoke(this);
                enemy.Die();
            }
        }

        public void Init(float speed, float lifetime)
        {
            _speed = speed;
            _lifetime = lifetime;
        }

        public void SetCallbackReturnToPool(Action<Bullet> callback) 
            => _hited = callback;
    }
}