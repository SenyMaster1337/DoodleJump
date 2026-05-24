using Code.Gameplay.PlayerComponents;
using Code.Services.LoseServices;

namespace Code.Services.PlayerDeathServices
{
    public class PlayerDeathHandlerServices : IPlayerDeathHandlerServices
    {
        private readonly ILoseService _loseService;

        private Player _player;

        public PlayerDeathHandlerServices(ILoseService loseService)
        {
            _loseService = loseService;
        }

        public void SetPlayer(Player player)
        {
            _player = player;
            _player.Dead += OnPlayerDead;
        }

        private void OnPlayerDead()
        {
            _player.Dead -= OnPlayerDead;
            _loseService.StartLoseProcess();
        }
    }
}