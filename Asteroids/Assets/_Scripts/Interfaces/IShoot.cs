using UnityEngine;

namespace Asteroids
{
    public interface IShoot
    {
        void Shoot(GameObject prefab, Transform positionSpawn);
    }
}
