using System;
using Code.StaticData.Platform;
using UnityEngine;

namespace Code.Gameplay.Platforms
{
    public class DefaultPlatform : MonoBehaviour, IPlatform
    {
        public Transform Transform { get; private set; }
        public GameObject GameObject { get; private set; }
        public PlatformType Type { get; private set; }

        private Action<IPlatform> _expired;

        private void Awake()
        {
            Transform = transform;
            GameObject = gameObject;
        }

        public void InitType(PlatformType platformType)
            => Type = platformType;

        public void SetCallbackReturnToPool(Action<IPlatform> returnCallback)
            => _expired = returnCallback;

        public void Expire() 
            => _expired?.Invoke(this);
    }
}