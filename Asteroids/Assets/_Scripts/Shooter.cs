using UnityEngine;

namespace Asteroids
{
    internal sealed class Shooter : IShoot
    {
        public void Shoot(GameObject prefab, Transform positionPrefab)
        {
            var ammunition = Projectile.CreateBlaster(prefab, positionPrefab);
            ammunition.Move();
        }
    }
}
