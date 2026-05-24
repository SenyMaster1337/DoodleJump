using Code.Infrastructure.Factory.UI;
using Code.Services.SaveLoad;
using UnityEngine;

namespace Code.Services.LoseServices
{
    public class LoseService : ILoseService
    {
        private readonly IUIFactory _uiFactory;
        private readonly ISaveLoadService _saveLoadService;

        public LoseService(IUIFactory uiFactory, ISaveLoadService saveLoadService)
        {
            _uiFactory = uiFactory;
            _saveLoadService = saveLoadService;
        }

        public void StartLoseProcess()
        {
            Time.timeScale = 0f;
            _saveLoadService.SaveProgress();
            _uiFactory.CreateRestartWindow();
        }
    }
}