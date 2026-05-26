using System;
using System.Collections;
using Code.StaticData.Platform;
using UnityEngine;

namespace Code.Gameplay.Platforms
{
    public class PlatformBreaker : MonoBehaviour, IPlatform, IConfigurablePlatform
    {
        public GameObject GameObject { get; private set; }
        public PlatformType Type { get; private set; }

        private Action<IPlatform> _expired;
        private float _delayToRemove;
        private Coroutine _breakCoroutine;

        private void Awake()
            => GameObject = gameObject;

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

        public void InitType(PlatformType platformType)
            => Type = platformType;

        public void InitSettings(PlatformSettingsData data)
            => _delayToRemove = data.PlatformBreakingData.DelayToRemove;

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