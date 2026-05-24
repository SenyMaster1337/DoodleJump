using System;
using UnityEngine;

namespace Code.StaticData.Enemy
{
    [Serializable]
    public class EnemyChanceData
    {
        public EnemyType Type;
        [Range(0f, 1f)] public float Chance;
    }
}