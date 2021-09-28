using UnityEngine;

namespace Asteroids
{
    public class BuilderProjectile
    {
        protected Projectile _projectile;

        public BuilderProjectile() => _projectile = new Blaster();
        protected BuilderProjectile(Projectile projectile) => _projectile = projectile;

        public ProjectileBuilderPrefab Prefab => new ProjectileBuilderPrefab(_projectile);

        public ProjectilePhysicsBuilder Physics => new ProjectilePhysicsBuilder(_projectile);

        public static implicit operator Projectile(BuilderProjectile builder)
        {
            return builder._projectile;
        }

    }
}
