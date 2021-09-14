using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Blaster : Projectile
    {
        private ViewServices<Blaster> _viewServices;
        public override void Move()
        {
            BodyBullet.velocity = transform.up * _force;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy();
        }

        public void SetPool(ViewServices<Blaster> viewServices)
        {
            _viewServices = viewServices;
        }

        public override void Execute()
        {
            _boundScreen.Execute(transform.position);
            if (_boundScreen.IsOnScreen == false)
            {
                Destroy();
            }
        }

        public override void Destroy()
        {
            _viewServices.Destroy(this);
        }
    }
}
