using System;
using Code.Services.PlayerInput;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.PlayerComponents.PlayerMovers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour
    {
        private IInputService _inputService;
        private Rigidbody2D _rigidbody;
        private float _moveSpeed;

        [Inject]
        public void Construct(IInputService inputService)
            => _inputService = inputService;

        private void Awake()
        {
            if (_inputService == null)
                throw new InvalidOperationException("InputService not injected");

            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float horizontal = _inputService.Horizontal;
            _rigidbody.velocity = new Vector2(horizontal * _moveSpeed, _rigidbody.velocity.y);
        }

        public void Init(float moveSpeed)
            => _moveSpeed = moveSpeed;
    }
}