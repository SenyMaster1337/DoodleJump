using Code.Core.Interfaces;
using Code.Core.LoadingCurtains;
using Code.Core.Signals;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.CoroutineRunners;
using Code.Infrastructure.GoogleAds;
using Code.Infrastructure.SceneLoaders;
using Code.Infrastructure.Services.GoogleAdsShowers;
using Code.Infrastructure.Services.LoadGameLevelServices;
using Code.Infrastructure.Services.PersistentProgress;
using Code.Infrastructure.Services.PlayerInput;
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
            BindProviders();
            BindStates();
            BindSceneLoader();
            BindServices();
            BindGoogleAds();
            BindSetups();
            BindSignals();
        }

        private void BindCoroutine() =>
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();

        private void BindServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadGameLevelService>().AsSingle();
            Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
            Container.Bind<IGoogleAdsShowerService>().To<GoogleAdsShowerService>().AsSingle();
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

        private void BindInputs()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<SceneLoader>().AsSingle();
        }

        private void BindGoogleAds()
        {
            Container.BindInterfacesAndSelfTo<InterAd>().AsSingle();
        }

        private void BindSetups()
        {
            Container.Bind<IAdsSetup>().To<AdsSetup>().AsSingle();
        }

        private void BindSignals()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<StartGameSignal>();
            Container.DeclareSignal<RestartGameSignal>();
        }
    }
}