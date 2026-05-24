using Code.Infrastructure.Factory.Game;
using Code.Infrastructure.Factory.Projectile;
using Code.Infrastructure.Factory.UI;
using Zenject;

namespace Code.Infrastructure.SceneInitializers.GameLevel
{
    public class SceneGameLevelInitializer : IInitializable
    {
        private readonly IUIFactory _uiFactory;
        private readonly IGameFactory _gameFactory;
        private readonly IProjectileFactory _projectileFactory;
        private readonly IInstantiator _instantiator;

        public SceneGameLevelInitializer(IUIFactory uiFactory, IGameFactory gameFactory,
            IProjectileFactory projectileFactory, IInstantiator instantiator)
        {
            _uiFactory = uiFactory;
            _gameFactory = gameFactory;
            _projectileFactory = projectileFactory;
            _instantiator = instantiator;
        }

        public void Initialize()
        {
            _uiFactory.SetSceneInstantiator(_instantiator);
            _gameFactory.SetSceneInstantiator(_instantiator);
            _projectileFactory.SetSceneInstantiator(_instantiator);
        }
    }
}