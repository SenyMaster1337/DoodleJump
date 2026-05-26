using Code.Infrastructure.Services.Setups.Camera;
using Code.Infrastructure.Services.Setups.Player;
using Code.Infrastructure.Services.Setups.Spawners;
using Code.Infrastructure.Services.Setups.UI.GameLevel;
using Zenject;

namespace Code.Infrastructure.SceneInitializers.GameLevel
{
    public class SceneGameLevelInitializer : IInitializable
    {
        private readonly ISpawnersSetup _spawnersSetup;
        private readonly IGameLevelUISetup _gameLevelUISetup;
        private readonly IPlayerSetup _playerSetup;
        private readonly ICameraSetup _cameraSetup;

        public SceneGameLevelInitializer(ISpawnersSetup spawnersSetup, IGameLevelUISetup gameLevelUISetup,
            IPlayerSetup playerSetup, ICameraSetup cameraSetup)
        {
            _spawnersSetup = spawnersSetup;
            _gameLevelUISetup = gameLevelUISetup;
            _playerSetup = playerSetup;
            _cameraSetup = cameraSetup;
        }

        public void Initialize()
        {
            _playerSetup.Init();
            _gameLevelUISetup.Init();
            _cameraSetup.Init();
            _spawnersSetup.Init();
        }
    }
}