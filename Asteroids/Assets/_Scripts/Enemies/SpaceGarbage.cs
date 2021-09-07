using UnityEngine;

namespace Asteroids
{
    public sealed class SpaceGarbage : Enemy
    {
        private ViewServices<SpaceGarbage> _viewServices;
        public override void Move(float speed, Transform transformTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                transformTarget.position, speed * Time.deltaTime);

            if (this.gameObject.activeInHierarchy == true)
            {
                if (Time.time > 30.0f)
                {
                    Destroy();
                }
            }
        }

        public void SetPool(ViewServices<SpaceGarbage> viewServices)
        {
            _viewServices = viewServices;
        }

        public override void Destroy()
        {
            _viewServices.Destroy(this);
        }
    }
}
