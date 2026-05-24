using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory.Projectile
{
    public interface IProjectileFactory
    {
        void SetSceneInstantiator(IInstantiator instantiator);
        GameObject CreateBullet();
    }
}