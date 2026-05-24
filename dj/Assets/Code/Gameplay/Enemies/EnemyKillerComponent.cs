using Code.Gameplay.PlayerComponents;
using UnityEngine;

namespace Code.Gameplay.Enemies
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class EnemyKillerComponent : MonoBehaviour
    {
        private void Awake() 
            => GetComponent<CircleCollider2D>().isTrigger = true;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Player>(out var player))
            {
                player.Die();
            }
        }
    }
}