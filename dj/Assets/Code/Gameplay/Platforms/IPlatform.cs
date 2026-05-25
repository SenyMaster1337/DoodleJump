using System;
using Code.StaticData.Platform;
using UnityEngine;

namespace Code.Gameplay.Platforms
{
    public interface IPlatform
    {
        Transform Transform { get; }
        GameObject GameObject { get; }
        PlatformType Type { get; }
        void InitType(PlatformType platformType);
        void SetCallbackReturnToPool(Action<IPlatform> returnCallback);
        void Expire();
    }
}