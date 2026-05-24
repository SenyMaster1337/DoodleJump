using Code.Infrastructure.SceneInitializers.GameLevel;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class GameLevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().To<SceneGameLevelInitializer>().AsSingle();
        }
    }
}