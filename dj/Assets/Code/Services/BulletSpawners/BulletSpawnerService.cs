using System.Collections.Generic;
using Code.Gameplay.Bullets;
using Code.Infrastructure.Factory.Projectile;
using UnityEngine;

namespace Code.Services.BulletSpawners
{
    public class BulletSpawnerService : IBulletSpawnerService
    {
        private readonly IProjectileFactory _factory;
        private readonly Queue<Bullet> _pool = new();
        private readonly List<Bullet> _active = new();

        public BulletSpawnerService(IProjectileFactory factory)
        {
            _factory = factory;
        }

        public void Spawn(Vector3 position, Vector2 direction)
        {
            Bullet projectile = GetFromPool() ?? _factory.CreateBullet().GetComponent<Bullet>();
            projectile.transform.position = position;
            projectile.transform.up = direction;
            projectile.SetCallbackReturnToPool(ReturnToPool);
            projectile.gameObject.SetActive(true);
            _active.Add(projectile);
        }

        public void ClearPool()
        {
            _pool.Clear();
            _active.Clear();
        }

        private void ReturnToPool(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            _active.Remove(bullet);
            _pool.Enqueue(bullet);
        }

        private Bullet GetFromPool() 
            => _pool.Count > 0 ? _pool.Dequeue() : null;
    }
}