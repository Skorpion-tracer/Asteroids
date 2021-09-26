using UnityEngine;

namespace Asteroids
{
    public class BlasterAttack : IAttack
    {
        private float _timeBtwShots;
        private float _startTimeBtwShots = 2;

        public Transform PositionSpawn { get; set; }

        private GameObject _prefab;

        public BlasterAttack(GameObject prefab)
        {
            _prefab = prefab;
        }

        public void Attack()
        {
            if (_timeBtwShots <= 0)
            {
                Object.Instantiate(_prefab, PositionSpawn.position, PositionSpawn.rotation);
                _timeBtwShots = _startTimeBtwShots;
            }
            else
            {
                _timeBtwShots -= Time.deltaTime;
            }
        }

    }
}
