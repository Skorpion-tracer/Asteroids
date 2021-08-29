using UnityEngine;

namespace Asteroids
{
    internal sealed class Shooter : IShoot
    {
        private Rigidbody2D _bodyBullet;
        private Transform _positionBullet;

        private float _force;

        public Shooter(Rigidbody2D bodyBullet, Transform positionBullet, float force)
        {
            _bodyBullet = bodyBullet;
            _positionBullet = positionBullet;
            _force = force;
        }

        public void Shoot()
        {
            var temAmmunition = Object.Instantiate(_bodyBullet, _positionBullet.position,
                _positionBullet.rotation);
            temAmmunition.AddForce(_positionBullet.up * _force);
        }
    }
}
