using Code.Gameplay.PlayerComponents;
using UnityEngine;

namespace Code.Gameplay.DeathZone
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class DeathZoneTrigger : MonoBehaviour
    {
        private void Awake() 
            => GetComponent<BoxCollider2D>().isTrigger = true;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Player>(out var player))
            {
                player.Die();
            }
        }
    }
}
