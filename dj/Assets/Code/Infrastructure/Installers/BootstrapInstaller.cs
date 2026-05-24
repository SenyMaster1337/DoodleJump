using Code.Gameplay.Score;
using Code.GoogleAds;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.CoroutineRunners;
using Code.Infrastructure.Factory.Game;
using Code.Infrastructure.Factory.Projectile;
using Code.Infrastructure.Factory.UI;
using Code.Infrastructure.SceneLoaders;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Factory;
using Code.Logic.LoadingCurtains;
using Code.Services.BulletSpawners;
using Code.Services.CameraProviders;
using Code.Services.EnemySpawner;
using Code.Services.GoogleAdsShowers;
using Code.Services.LoadGameLevelServices;
using Code.Services.LoseServices;
using Code.Services.PersistentProgress;
using Code.Services.PlatformSpawner;
using Code.Services.PlayerDeathServices;
using Code.Services.PlayerInput;
using Code.Services.RestartGameServices;
using Code.Services.SaveLoad;
using Code.Services.ScoreShowerServices;
using Code.Services.StaticData;
using Code.Signals.RestartGameSignals;
using Code.Signals.StartGameSignals;
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
        }

        private void BindCoroutine() =>
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();

        private void BindServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
            Container.Bind<IPlatformSpawnService>().To<PlatformSpawnService>().AsSingle();
            Container.Bind<IEnemySpawnerService>().To<EnemySpawnerService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreShowerService>().AsSingle();
            Container.Bind<IBulletSpawnerService>().To<BulletSpawnerService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadGameLevelService>().AsSingle();
            Container.Bind<IPlayerDeathHandlerServices>().To<PlayerDeathHandlerServices>().AsSingle();
            Container.Bind<ILoseService>().To<LoseService>().AsSingle();
            Container.BindInterfacesAndSelfTo<RestartGameService>().AsSingle();
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
            Container.Bind<GameLoopState>().AsSingle();
        }

        private void BindProviders()
        {
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
            Container.Bind<IScoreByHeightProvider>().To<ScoreByHeightProvider>().AsSingle();
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
    }
}