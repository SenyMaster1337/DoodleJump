using UnityEngine;

namespace Code.StaticData.Enemy
{
    [CreateAssetMenu(fileName = "EnemyStaticData", menuName = "StaticData/EnemyStaticData")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyType Type;
        public EnemyData EnemyData;
    }
}