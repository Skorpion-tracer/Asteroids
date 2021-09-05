using UnityEngine;

namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        void Move(bool isInput, float x, float y);
    }
}
