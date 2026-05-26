using Code.Infrastructure.Factory.UI;
using Code.Infrastructure.Services.ScoreShowerServices;

namespace Code.Infrastructure.Services.Setups.UI.GameLevel
{
    public class GameLevelUISetup : IGameLevelUISetup
    {
        private readonly IUIFactory _uiFactory;
        private readonly IScoreShowerService _scoreShowerService;

        public GameLevelUISetup(IUIFactory uiFactory, IScoreShowerService scoreShowerService)
        {
            _uiFactory = uiFactory;
            _scoreShowerService = scoreShowerService;
        }

        public void Init()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateHud();
            _scoreShowerService.Init();
        }
    }
}