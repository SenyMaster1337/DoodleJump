using UnityEngine;

namespace Code.Gameplay.PlayerComponents.PlayerJumpers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerJumper : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private float _jumpForce;

        private void Awake() 
            => _rigidbody = GetComponent<Rigidbody2D>();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.contacts[0].normal.y > 0.5f)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f);
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }

        public void Init(float jumpForce) 
            => _jumpForce = jumpForce;
    }
}