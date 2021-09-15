using UnityEngine;

namespace Asteroids
{
    public sealed class ProjectilePhysicsBuilder : BuilderProjectile
    {
        public ProjectilePhysicsBuilder(Projectile projectile) : 
            base(projectile) { }

        public ProjectilePhysicsBuilder BoxCollider2D()
        {
            GetOrAddComponent<BoxCollider2D>();
            return this;
        }

        public ProjectilePhysicsBuilder Rigidbody2D(float mass)
        {
            var component = GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            return this;
        }

        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _projectile.gameObject.GetComponent<T>();
            if (!result)
            {
                result = _projectile.gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}
