namespace Code.Gameplay.PlayerComponents.PlayerProviders
{
    public interface IPlayerProvider
    {
        Player Player { get; }
        void SetPlayer(Player player);
    }
}