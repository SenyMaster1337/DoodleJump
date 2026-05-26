using Code.Infrastructure.Factory.UI;
using Code.Infrastructure.Services.GameTime;
using Code.Infrastructure.Services.SaveLoad;

namespace Code.Infrastructure.Services.LoseServices
{
    public class LoseService : ILoseService
    {
        private readonly IUIFactory _uiFactory;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IGameTimeService _gameTimeService;

        public LoseService(IUIFactory uiFactory, ISaveLoadService saveLoadService, IGameTimeService gameTimeService)
        {
            _uiFactory = uiFactory;
            _saveLoadService = saveLoadService;
            _gameTimeService = gameTimeService;
        }

        public void StartLoseProcess()
        {
            _gameTimeService.Pause();
            _saveLoadService.SaveProgress();
            _uiFactory.CreateRestartWindow();
        }
    }
}