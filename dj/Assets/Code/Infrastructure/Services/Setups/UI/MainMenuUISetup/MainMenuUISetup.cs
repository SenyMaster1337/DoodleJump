using Code.Infrastructure.Factory.UI;

namespace Code.Infrastructure.Services.Setups.UI.MainMenuUISetup
{
    public class MainMenuUISetup : IMainMenuUISetup
    {
        private readonly IUIFactory _uiFactory;

        public MainMenuUISetup(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Init()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateControlsInstruction();
            _uiFactory.CreateStartButton();
        }
    }
}