using Code.Core.Interfaces;
using Code.Core.LoadingCurtains;
using Code.Core.Signals;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.CoroutineRunners;
using Code.Infrastructure.Factory.Game;
using Code.Infrastructure.Factory.ProjectileFactory;
using Code.Infrastructure.Factory.UI;
using Code.Infrastructure.GoogleAds;
using Code.Infrastructure.SceneLoaders;
using Code.Infrastructure.Services.GameTime;
using Code.Infrastructure.Services.GoogleAdsShowers;
using Code.Infrastructure.Services.LoadGameLevelServices;
using Code.Infrastructure.Services.LoseServices;
using Code.Infrastructure.Services.PersistentProgress;
using Code.Infrastructure.Services.PlayerInput;
using Code.Infrastructure.Services.RestartGameServices;
using Code.Infrastructure.Services.SaveLoad;
using Code.Infrastructure.Services.Setups.Ads;
using Code.Infrastructure.Services.StaticData;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Factory;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindCoroutine();
            BindInputs();
            BindFactories();
            BindProviders();
            BindStates();
            BindSceneLoader();
            BindServices();
            BindSignals();
            BindGoogleAds();
            BindSetups();
        }

        private void BindCoroutine() =>
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();

        private void BindServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadGameLevelService>().AsSingle();
            Container.Bind<ILoseService>().To<LoseService>().AsSingle();
            Container.BindInterfacesAndSelfTo<RestartGameService>().AsSingle();
            Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
            Container.Bind<IGoogleAdsShowerService>().To<GoogleAdsShowerService>().AsSingle();
            Container.Bind<IGameTimeService>().To<GameTimeService>().AsSingle();
        }

        private void BindStates()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LoadMainMenuState>().AsSingle();
            Container.Bind<LoadProgressState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
        }

        private void BindProviders()
        {
            Container.Bind<ILoadingCurtainProvider>().To<LoadingCurtainProvider>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle();
        }

        private void BindInputs()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        }

        private void BindSceneLoader() =>
            Container.Bind<SceneLoader>().AsSingle();

        private void BindSignals()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<StartGameSignal>();
            Container.DeclareSignal<RestartGameSignal>();
        }

        private void BindGoogleAds()
        {
            Container.BindInterfacesAndSelfTo<InterAd>().AsSingle();
        }

        private void BindSetups()
        {
            Container.Bind<IAdsSetup>().To<AdsSetup>().AsSingle();
        }
    }
}