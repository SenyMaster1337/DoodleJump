using Code.Infrastructure.Factory.UI;
using Zenject;

namespace Code.Infrastructure.SceneInitializers.MainMenu
{
    public class SceneMainMenuInitializer : IInitializable
    {
        private readonly IUIFactory _uiFactory;
        private readonly IInstantiator _instantiator;

        public SceneMainMenuInitializer(IUIFactory uiFactory, IInstantiator instantiator)
        {
            _uiFactory = uiFactory;
            _instantiator = instantiator;
        }

        public void Initialize()
        {
            _uiFactory.SetSceneInstantiator(_instantiator);
        }
    }
}