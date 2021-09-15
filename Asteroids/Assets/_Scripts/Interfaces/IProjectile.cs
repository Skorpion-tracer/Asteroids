using UnityEngine;

namespace Asteroids
{
    public interface IProjectile
    {
        int Damage { get; set; }
        Blaster CreateBlaster(GameObject prefab, Transform positionPrefab);
    }
}
