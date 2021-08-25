using UnityEngine;

namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        void Move(Transform transform, bool isInput, float x, float y);
    }
}
