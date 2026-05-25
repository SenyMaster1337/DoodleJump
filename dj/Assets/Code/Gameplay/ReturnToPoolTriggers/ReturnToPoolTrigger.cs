using Code.Gameplay.Enemies;
using Code.Gameplay.Platforms;
using UnityEngine;


namespace Code.Logic.ReturnToPoolTriggers
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ReturnToPoolTrigger : MonoBehaviour
    {
        private void Awake()
            => GetComponent<BoxCollider2D>().isTrigger = true;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IPlatform>(out var platform))
                platform.Expire();
            else if (other.TryGetComponent<IEnemy>(out var enemy))
                enemy.Die();
        }
    }
}