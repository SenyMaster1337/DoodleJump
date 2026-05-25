using Code.StaticData.Enemy;

namespace Code.Gameplay.Enemies
{
    public interface IConfigurableEnemy
    {
        void InitSettings(EnemySettingsData data);
    }
}