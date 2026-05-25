using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory.ProjectileFactory
{
    public interface IProjectileFactory
    {
        void SetSceneInstantiator(IInstantiator instantiator);
        GameObject CreateBullet();
    }
}