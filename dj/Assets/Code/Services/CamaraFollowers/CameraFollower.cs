using UnityEngine;

namespace Code.Services.CamaraFollowers
{
    public class CameraFollower : MonoBehaviour
    {
        private Transform _targetTransform;
        private float _smoothTime;
        
        private float _velocityY;
        private float _highestCameraY;

        private void Awake() 
            => _highestCameraY = transform.position.y;

        private void LateUpdate()
        {
            if (_targetTransform == null)
                return;

            if (_targetTransform.position.y > _highestCameraY)
            {
                _highestCameraY = _targetTransform.position.y;
            }

            float newY =
                Mathf.SmoothDamp(transform.position.y, _highestCameraY, ref _velocityY, _smoothTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
        
        public void Init(Transform targetTransform, float smoothTime)
        {
            _targetTransform = targetTransform;
            _smoothTime = smoothTime;
        }
    }
}