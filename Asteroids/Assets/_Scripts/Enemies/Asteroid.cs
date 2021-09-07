using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : Enemy
    {
        private ViewServices<Asteroid> _viewServices;
        public override void Move(float speed, Transform transformTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                transformTarget.position, speed * Time.deltaTime);

            if (this.gameObject.activeInHierarchy == true)
            {
                if (Time.time > 10.0f)
                {
                    Destroy();
                }
            }
        }

        public void SetPool(ViewServices<Asteroid> viewServices)
        {
            _viewServices = viewServices;
        }

        public override void Destroy()
        {
            _viewServices.Destroy(this);
        }
    }
}
