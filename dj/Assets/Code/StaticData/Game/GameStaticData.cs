using Code.StaticData.Bullet;
using Code.StaticData.Enemy;
using Code.StaticData.Platform;
using Code.StaticData.Player;
using UnityEngine;

namespace Code.StaticData.Game
{
    [CreateAssetMenu(fileName = "GameData", menuName = "StaticData/Game")]
    public class GameStaticData : ScriptableObject
    {
        public string SceneKey;
        public Vector3 StartSpawnPosition;
        public CameraSettingsData CameraSettingsData;
        public PlayerSettingsData PlayerSettingsData;
        public BulletSettingsData BulletSettingsData;
        public PlatformsSpawnData PlatformsSpawnData;
        public PlatformSettingsData PlatformSettingsData;
        public EnemySpawnData EnemySpawnData;
        public EnemySettingsData EnemySettingsData;
    }
}