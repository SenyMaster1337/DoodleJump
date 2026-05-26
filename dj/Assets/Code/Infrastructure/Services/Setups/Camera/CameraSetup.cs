using Code.Gameplay.PlayerComponents.PlayerProviders;
using Code.Infrastructure.SceneNameConstants;
using Code.Infrastructure.Services.CameraFollowers;
using Code.Infrastructure.Services.CameraProviders;
using Code.Infrastructure.Services.StaticData;
using Code.StaticData.Game;

namespace Code.Infrastructure.Services.Setups.Camera
{
    public class CameraSetup : ICameraSetup
    {
        private readonly ICameraProvider _cameraProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly IPlayerProvider _playerProvider;

        public CameraSetup(ICameraProvider cameraProvider, IStaticDataService staticDataService,
            IPlayerProvider playerProvider)
        {
            _cameraProvider = cameraProvider;
            _staticDataService = staticDataService;
            _playerProvider = playerProvider;
        }

        public void Init()
        {
            CameraSettingsData cameraSettingsData =
                _staticDataService.GetGameStaticData(SceneNames.Main).CameraSettingsData;

            _cameraProvider.MainCamera.GetComponent<CameraFollower>()
                .Init(_playerProvider.Player.transform, cameraSettingsData.SmoothTimeFollowToPlayer);
        }
    }
}