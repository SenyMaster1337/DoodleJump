using Code.Infrastructure.Factory.UI;
using Code.Infrastructure.SceneInitializers.MainMenu;
using Code.Infrastructure.Services.Setups.UI.MainMenuUISetup;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactories();
            BindSetups();
            BindInitializers();
        }

        private void BindFactories()
        {
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }

        private void BindSetups()
        {
            Container.Bind<IMainMenuUISetup>().To<MainMenuUISetup>().AsSingle();
        }

        private void BindInitializers()
        {
            Container.Bind<IInitializable>().To<SceneMainMenuInitializer>().AsSingle();
        }
    }
}