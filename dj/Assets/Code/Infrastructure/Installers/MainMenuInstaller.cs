using Code.Infrastructure.SceneInitializers.MainMenu;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().To<SceneMainMenuInitializer>().AsSingle();
        }
    }
}