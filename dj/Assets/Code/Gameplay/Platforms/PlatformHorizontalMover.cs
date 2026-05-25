using System;
using Code.Gameplay.Common;
using Code.StaticData.Platform;
using UnityEngine;

namespace Code.Gameplay.Platforms
{
    public class PlatformHorizontalMover : HorizontalPingPongMover, IPlatform
    {
        public PlatformType Type { get; private set; }
        public Transform Transform { get; private set; }
        public GameObject GameObject { get; private set; }

        private Action<IPlatform> _expired;

        private void Awake()
        {
            Transform = transform;
            GameObject = gameObject;
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