using System.Collections.Generic;

namespace Code.Infrastructure.Services.LevelReset
{
    public class LevelResetService : ILevelResetService
    {
        private readonly List<ILevelReset> _resettableServices;

        public LevelResetService(List<ILevelReset> resettableServices)
        {
            _resettableServices = resettableServices;
        }

        public void StartResetProcess()
        {
            foreach (var service in _resettableServices)
                service.Reset();
        }
    }
}