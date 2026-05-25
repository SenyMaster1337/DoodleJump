using Code.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.PlayerComponents.PlayerShooters
{
    public class PlayerShooter : MonoBehaviour
    {
        private const float SpawnOffsetY = 0.75f;

        private IInputService _inputService;
        private IBulletSpawnerService _spawnService;

        [Inject]
        private void Construct(IInputService inputService, IBulletSpawnerService spawnService)
        {
            _inputService = inputService;
            _spawnService = spawnService;
        }

        private void Update()
        {
            if (_inputService.IsFirePressed)
            {
                Vector3 spawnPosition = transform.position + Vector3.up * SpawnOffsetY;
                _spawnService.Spawn(spawnPosition, Vector2.up);
            }
        }
    }
}