using Code.Infrastructure.Factory.UI;
using Code.Infrastructure.Services.Setups.UI.MainMenuUISetup;
using Zenject;

namespace Code.Infrastructure.SceneInitializers.MainMenu
{
    public class SceneMainMenuInitializer : IInitializable
    {
        private readonly IMainMenuUISetup _mainMenuUISetup;
        private readonly IUIFactory _uiFactory;

        public SceneMainMenuInitializer(IMainMenuUISetup mainMenuUISetup, IUIFactory uiFactory)
        {
            _mainMenuUISetup = mainMenuUISetup;
            _uiFactory = uiFactory;
        }

        public void Initialize()
        {
            _uiFactory.CreateUIRoot();
            _mainMenuUISetup.Init();
        }
    }
}