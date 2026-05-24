using UnityEngine;

namespace Code.Gameplay.Platforms
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpringComponentToPlatform : MonoBehaviour
    {
        private float _springForce;

        private void Awake() 
            => GetComponent<BoxCollider2D>().isTrigger = true;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.attachedRigidbody != null && other.attachedRigidbody.velocity.y <= 0)
            {
                other.attachedRigidbody.velocity = new Vector2(other.attachedRigidbody.velocity.x, _springForce);
            }
        }

        public void Init(float springForce) 
            => _springForce = springForce;
    }
}
