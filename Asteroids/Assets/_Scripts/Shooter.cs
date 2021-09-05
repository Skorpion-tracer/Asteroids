using UnityEngine;

namespace Asteroids
{
    internal sealed class Shooter : IShoot
    {
        private Transform _positionBullet;

        public Shooter(Transform positionBullet)
        {
            _positionBullet = positionBullet;
        }

        public void Shoot()
        {
            var ammunition = Projectile.CreateBlaster(_positionBullet);
            ammunition.Move();
            //temAmmunition.AddForce(_positionBullet.up * _force);
        }
    }
}
