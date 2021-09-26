using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyProjectile : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _bodyProjectile;
        private float _forceDamage = 20;

        private void Start()
        {
            _bodyProjectile = GetComponent<Rigidbody2D>();

            _bodyProjectile.AddForce(transform.up * _speed);

            Destroy(gameObject, 15);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Player>(out Player player))
            {
                player.Hurt(_forceDamage);
                Destroy(gameObject);
            }
        }
    }
}
