using UnityEngine;

namespace Code.Infrastructure.Services.CameraProviders
{
    public interface ICameraProvider
    {
        public Camera MainCamera { get; }
        public void SetCamera(Camera camera);
    }
}