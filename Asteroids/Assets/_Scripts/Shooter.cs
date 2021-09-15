using UnityEngine;

namespace Asteroids
{
    public sealed class Shooter : IShoot
    {
        private IProjectile _projectile;
        public Shooter(IProjectile projectile)
        {
            _projectile = projectile;
        }
        public void Shoot(GameObject prefab, Transform positionPrefab)
        {
            var ammunition = _projectile.CreateBlaster(prefab, positionPrefab);
            ammunition.Move();
        }
    }
}
