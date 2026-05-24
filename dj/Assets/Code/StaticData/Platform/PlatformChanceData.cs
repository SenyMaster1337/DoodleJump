using System;
using UnityEngine;

namespace Code.StaticData.Platform
{
    [Serializable]
    public class PlatformChanceData
    {
        public PlatformType Type;
        [Range(0f, 1f)] public float Chance;
    }
}