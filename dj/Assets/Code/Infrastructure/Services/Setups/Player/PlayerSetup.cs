using Code.Infrastructure.Factory.Game;

namespace Code.Infrastructure.Services.Setups.Player
{
    public class PlayerSetup : IPlayerSetup
    {
        private readonly IGameFactory _gameFactory;

        public PlayerSetup(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Init() 
            => _gameFactory.CreatePlayer();
    }
}