using Code.StaticData.Platform;

namespace Code.Gameplay.Platforms
{
    public interface IConfigurablePlatform
    {
        void InitSettings(PlatformSettingsData data);
    }
}