using System;
using System.Collections;
using Code.StaticData.Platform;
using UnityEngine;

namespace Code.Gameplay.Platforms
{
    public class PlatformBreaker : MonoBehaviour, IPlatform
    {
        public Transform Transform { get; private set; }
        public GameObject GameObject { get; private set; }
        public PlatformType Type { get; private set; }

        private Action<IPlatform> _expired;
        private float _delayToRemove;
        private Coroutine _breakCoroutine;

        private void Awake()
        {
            Transform = transform;
            GameObject = gameObject;
        }

        private void OnEnable()
        {
            _breakCoroutine = null;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.rigidbody.velocity.y <= 0 && _breakCoroutine == null)
            {
                _breakCoroutine = StartCoroutine(DisableAfterDelay());
            }
        }

        public void Init(PlatformType platformType, PlatformSettingsData data)
        {
            Type = platformType;
            _delayToRemove = data.PlatformBreakingData.DelayToRemove;
        }

        public void SetCallbackReturnToPool(Action<IPlatform> returnCallback)
            => _expired = returnCallback;

        public void Expire()
        {
            if (_breakCoroutine != null)
            {
                StopCoroutine(_breakCoroutine);
                _breakCoroutine = null;
            }

            _expired?.Invoke(this);
        }

        private IEnumerator DisableAfterDelay()
        {
            yield return new WaitForSeconds(_delayToRemove);
            Expire();
        }
    }
}