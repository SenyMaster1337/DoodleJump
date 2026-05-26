using Code.Infrastructure.Factory.Game;
using Code.Infrastructure.Factory.ProjectileFactory;
using Code.Infrastructure.Factory.UI;
using Code.Infrastructure.Services.Setups.Camera;
using Code.Infrastructure.Services.Setups.Player;
using Code.Infrastructure.Services.Setups.Spawners;
using Code.Infrastructure.Services.Setups.UI;
using Zenject;

namespace Code.Infrastructure.SceneInitializers.GameLevel
{
    public class SceneGameLevelInitializer : IInitializable
    {
        private readonly IUIFactory _uiFactory;
        private readonly IGameFactory _gameFactory;
        private readonly IProjectileFactory _projectileFactory;
        private readonly ISpawnersSetup _spawnersSetup;
        private readonly IUISetup _uiSetup;
        private readonly IPlayerSetup _playerSetup;
        private readonly ICameraSetup _cameraSetup;
        private readonly IInstantiator _instantiator;

        public SceneGameLevelInitializer(IUIFactory uiFactory, IGameFactory gameFactory,
            IProjectileFactory projectileFactory, ISpawnersSetup spawnersSetup, IUISetup uiSetup,
            IPlayerSetup playerSetup, ICameraSetup cameraSetup, IInstantiator instantiator)
        {
            _uiFactory = uiFactory;
            _gameFactory = gameFactory;
            _projectileFactory = projectileFactory;
            _spawnersSetup = spawnersSetup;
            _uiSetup = uiSetup;
            _playerSetup = playerSetup;
            _cameraSetup = cameraSetup;
            _instantiator = instantiator;
        }

        public void Initialize()
        {
            _uiFactory.SetSceneInstantiator(_instantiator);
            _gameFactory.SetSceneInstantiator(_instantiator);
            _projectileFactory.SetSceneInstantiator(_instantiator);

            _playerSetup.Init();
            _uiSetup.Init();
            _cameraSetup.Init();
            _spawnersSetup.Init();
        }
    }
}