using System;
using Code.StaticData.Platform;
using UnityEngine;

namespace Code.Gameplay.Platforms
{
    public class PlatformHorizontalMover : MonoBehaviour, IPlatform
    {
        public PlatformType Type { get; private set; }
        public Transform Transform { get; private set; }
        public GameObject GameObject { get; private set; }

        private float _speed;
        private float _range;
        private float _startX;

        private Action<IPlatform> _expired;

        private void Awake()
        {
            Transform = transform;
            GameObject = gameObject;
        }

        private void OnEnable()
            => _startX = transform.position.x;

        private void Update()
        {
            float x = _startX + Mathf.PingPong(Time.time * _speed, _range * 2) - _range;

            transform.position =
                new Vector3(x, transform.position.y, transform.position.z);
        }

        public void Init(PlatformType platformType, PlatformSettingsData data)
        {
            Type = platformType;
            _speed = data.platformHorizontalMovingData.MoveSpeed;
            _range = data.platformHorizontalMovingData.RangeHorizontalMoving;
        }

        public void SetCallbackReturnToPool(Action<IPlatform> returnCallback)
            => _expired = returnCallback;

        public void Expire()
            => _expired?.Invoke(this);
    }
}