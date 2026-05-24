using Code.StaticData.Enemy;
using Code.StaticData.Game;
using Code.StaticData.Platform;

namespace Code.Services.StaticData
{
    public interface IStaticDataService
    {
        GameStaticData GetGameStaticData(string sceneKey);
        PlatformData GetPlatformData(PlatformType platformType);
        EnemyData GetEnemyData(EnemyType enemyType);
    }
}