using UnityEngine;

namespace Code.Services.BulletSpawners
{
    public interface IBulletSpawnerService
    {
        void Spawn(Vector3 position, Vector2 direction);
        void ClearPool();
    }
}