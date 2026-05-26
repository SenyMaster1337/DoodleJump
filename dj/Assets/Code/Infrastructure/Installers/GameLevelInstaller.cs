using Code.Gameplay.PlayerComponents.PlayerProviders;
using Code.Gameplay.Score;
using Code.Infrastructure.Factory.Game;
using Code.Infrastructure.Factory.ProjectileFactory;
using Code.Infrastructure.Factory.UI;
using Code.Infrastructure.SceneInitializers.GameLevel;
using Code.Infrastructure.Services.BulletSpawners;
using Code.Infrastructure.Services.CameraProviders;
using Code.Infrastructure.Services.EnemySpawner;
using Code.Infrastructure.Services.GameTime;
using Code.Infrastructure.Services.LevelReset;
using Code.Infrastructure.Services.LoseServices;
using Code.Infrastructure.Services.PlatformSpawner;
using Code.Infrastructure.Services.RestartGameServices;
using Code.Infrastructure.Services.ScoreShowerServices;
using Code.Infrastructure.Services.Setups.Camera;
using Code.Infrastructure.Services.Setups.Player;
using Code.Infrastructure.Services.Setups.Spawners;
using Code.Infrastructure.Services.Setups.UI.GameLevel;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class GameLevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactories();
            BindServices();
            BindProviders();
            BindSetups();
            BindSpawners();
            BindInitializers();
        }

        private void BindFactories()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<RestartGameService>().AsSingle();
            Container.Bind<ILoseService>().To<LoseService>().AsSingle();
            Container.Bind<IGameTimeService>().To<GameTimeService>().AsSingle();
            Container.Bind<ILevelResetService>().To<LevelResetService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreShowerService>().AsSingle();
        }

        private void BindProviders()
        {
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
            Container.Bind<IScoreByHeightProvider>().To<ScoreByHeightProvider>().AsSingle();
            Container.Bind<IPlayerProvider>().To<PlayerProvider>().AsSingle();
        }

        private void BindSetups()
        {
            Container.Bind<IPlayerSetup>().To<PlayerSetup>().AsSingle();
            Container.Bind<ICameraSetup>().To<CameraSetup>().AsSingle();
            Container.Bind<ISpawnersSetup>().To<SpawnersSetup>().AsSingle();
            Container.Bind<IGameLevelUISetup>().To<GameLevelUISetup>().AsSingle();
        }

        private void BindSpawners()
        {
            Container.BindInterfacesAndSelfTo<PlatformSpawnerService>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemySpawnerService>().AsSingle();
            Container.BindInterfacesAndSelfTo<BulletSpawnerService>().AsSingle();
        }

        private void BindInitializers()
        {
            Container.Bind<IInitializable>().To<SceneGameLevelInitializer>().AsSingle();
        }
    }
}