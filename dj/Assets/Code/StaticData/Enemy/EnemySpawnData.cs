using System;
using System.Collections.Generic;

namespace Code.StaticData.Enemy
{
    [Serializable]
    public class EnemySpawnData
    {
        public float EnemyOffsetY;
        public float ScoreToStartSpawn;

        public List<EnemyChanceData> EnemyChances;
    }
}