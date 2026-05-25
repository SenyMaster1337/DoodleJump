using UnityEngine;

namespace Code.Gameplay.Common
{
    public class HorizontalPingPongMover : MonoBehaviour
    {
        private const float PingPongMultiplier = 2f;
        
        private float _startX;
        
        protected float _speed;
        protected float _range;
        
        private void OnEnable() 
            => _startX = transform.position.x;

        private void Update()
        {
            float x = _startX + Mathf.PingPong(Time.time * _speed, _range * PingPongMultiplier) - _range;

            transform.position =
                new Vector3(x, transform.position.y, transform.position.z);
        }
    }
}