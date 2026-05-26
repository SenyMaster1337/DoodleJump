using System;

namespace Code.Gameplay.PlayerComponents.PlayerProviders
{
    public class PlayerProvider : IPlayerProvider
    {
        public Player Player { get; private set; }

        public void SetPlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player), "Player cannot be null.");

            Player = player;
        }
    }
}