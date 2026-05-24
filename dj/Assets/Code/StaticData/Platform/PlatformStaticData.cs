using UnityEngine;

namespace Code.StaticData.Platform
{
    [CreateAssetMenu(fileName = "PlatformStaticData", menuName = "StaticData/PlatformStaticData")]
    public class PlatformStaticData : ScriptableObject
    {
        public PlatformType PlatformType;
        public PlatformData PlatformData;
    }
}