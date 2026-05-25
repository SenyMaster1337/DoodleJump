using Code.Gameplay.Bullets;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.SceneNameConstants;
using Code.Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory.ProjectileFactory
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;

        private IInstantiator _instantiator;

        public ProjectileFactory(IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public void SetSceneInstantiator(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public GameObject CreateBullet()
        {
            var bulletPrefab = _assetProvider.Load(AssetPath.BulletPath);

            var data = _staticDataService.GetGameStaticData(SceneNames.Main).BulletSettingsData;

            GameObject bullet = _instantiator.InstantiatePrefab(bulletPrefab);
            bullet.GetComponent<Bullet>().Init(data.Speed, data.Lifetime);

            return bullet;
        }
    }
}