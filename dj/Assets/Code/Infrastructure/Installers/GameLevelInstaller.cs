using Code.Core.Interfaces;
using Code.Gameplay.PlayerComponents.PlayerProviders;
using Code.Gameplay.Score;
using Code.Infrastructure.SceneInitializers.GameLevel;
using Code.Infrastructure.Services.BulletSpawners;
using Code.Infrastructure.Services.CameraProviders;
using Code.Infrastructure.Services.EnemySpawner;
using Code.Infrastructure.Services.PlatformSpawner;
using Code.Infrastructure.Services.ScoreShowerServices;
using Code.Infrastructure.Services.Setups.Camera;
using Code.Infrastructure.Services.Setups.Player;
using Code.Infrastructure.Services.Setups.Spawners;
using Code.Infrastructure.Services.Setups.UI;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class GameLevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInitializers();
            BindServices();
            BindProviders();
            BindSetups();
            BindSpawners();
        }

        private void BindInitializers()
        {
            Container.Bind<IInitializable>().To<SceneGameLevelInitializer>().AsSingle();
        }

        private void BindServices()
        {
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
            Container.Bind<IUISetup>().To<UISetup>().AsSingle();
        }

        private void BindSpawners()
        {
            Container.Bind<IPlatformSpawnerService>().To<PlatformSpawnerService>().AsSingle();
            Container.Bind<IEnemySpawnerService>().To<EnemySpawnerService>().AsSingle();
            Container.Bind<IBulletSpawnerService>().To<BulletSpawnerService>().AsSingle();
        }
    }
}