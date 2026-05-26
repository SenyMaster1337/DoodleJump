using UnityEngine;

namespace Code.Core.Interfaces
{
    public interface IBulletSpawnerService
    {
        void Spawn(Vector3 position, Vector2 direction);
    }
}