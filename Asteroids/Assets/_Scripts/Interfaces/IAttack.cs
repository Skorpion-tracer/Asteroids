using UnityEngine;

namespace Asteroids
{
    public interface IAttack
    {
        Transform PositionSpawn { get; set; }
        void Attack();
    }
}
