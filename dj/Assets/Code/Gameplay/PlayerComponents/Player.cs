using System;
using Code.Gameplay.PlayerComponents.PlayerProviders;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.PlayerComponents
{
    public class Player : MonoBehaviour
    {
        public event Action Dead;

        private IPlayerProvider _playerProvider;
        
        [Inject]
        private void Construct(IPlayerProvider playerProvider) 
            => _playerProvider = playerProvider;

        private void Awake() 
            => _playerProvider.SetPlayer(this);

        public void Die()
            => Dead?.Invoke();
    }
}