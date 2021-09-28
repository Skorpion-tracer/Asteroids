using UnityEngine;

namespace Asteroids
{
    public interface IMotion
    {
        void Move(Transform enemy, Transform player, float speed);
    }
}
