using UnityEngine;

namespace Code.Infrastructure.Services.GameTime
{
    public class GameTimeService : IGameTimeService
    {
        public void Pause() 
            => Time.timeScale = 0f;

        public void Resume() 
            => Time.timeScale = 1f;
    }
}