using UnityEngine;

namespace Asteroids
{
    public sealed class ProjectileBuilderPrefab : BuilderProjectile
    {
        public ProjectileBuilderPrefab(Projectile projectile) :
            base(projectile) { }

        public ProjectileBuilderPrefab Prefab(GameObject prefab)
        {
            _projectile = prefab.GetComponent<Blaster>();
            return this;
        }
    }
}
