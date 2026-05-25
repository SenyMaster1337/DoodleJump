using System;
using Code.StaticData.Platform;
using UnityEngine;

namespace Code.Gameplay.Platforms
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlatformSpringy : MonoBehaviour, IPlatform, IConfigurablePlatform
    {
        public Transform Transform { get; private set; }
        public GameObject GameObject { get; private set; }
        public PlatformType Type { get; private set; }

        private SpringComponentToPlatform _springComponentToPlatform;

        private Action<IPlatform> _expired;

        private void Awake()
        {
            _springComponentToPlatform = GetComponentInChildren<SpringComponentToPlatform>();

            Transform = transform;
            GameObject = gameObject;
        }

        public void InitType(PlatformType platformType) 
            => Type = platformType;

        public void InitSettings(PlatformSettingsData data) 
            => _springComponentToPlatform.Init(data.PlatformSpringingData.SpringForce);

        public void SetCallbackReturnToPool(Action<IPlatform> returnCallback)
            => _expired = returnCallback;

        public void Expire()
            => _expired?.Invoke(this);
    }
}