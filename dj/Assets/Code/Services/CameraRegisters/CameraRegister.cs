using Code.Services.CameraProviders;
using UnityEngine;
using Zenject;

namespace Code.Services.CameraRegisters
{
    [RequireComponent(typeof(Camera))]
    public class CameraRegister : MonoBehaviour
    {
        private Camera _mainCamera;
        private ICameraProvider _cameraProvider;

        [Inject]
        public void Construct(ICameraProvider cameraProvider) 
            => _cameraProvider = cameraProvider;

        private void Awake()
        {
            _mainCamera = GetComponent<Camera>();
            _cameraProvider.SetCamera(_mainCamera);
        }
    }
}
