using System;
using Code.Gameplay.Common;
using Code.StaticData.Platform;
using UnityEngine;

namespace Code.Gameplay.Platforms
{
    public class PlatformHorizontalMover : HorizontalPingPongMover, IPlatform, IConfigurablePlatform
    {
        public PlatformType Type { get; private set; }
        public GameObject GameObject { get; private set; }

        private Action<IPlatform> _expired;

        private void Awake() 
            => GameObject = gameObject;

        public void InitType(PlatformType platformType) 
            => Type = platformType;

        public void InitSettings(PlatformSettingsData data)
        {
            _speed = data.PlatformHorizontalMovingData.MoveSpeed;
            _range = data.PlatformHorizontalMovingData.RangeHorizontalMoving;
        }

        public void SetCallbackReturnToPool(Action<IPlatform> returnCallback)
            => _expired = returnCallback;

        public void Expire()
            => _expired?.Invoke(this);
    }
}