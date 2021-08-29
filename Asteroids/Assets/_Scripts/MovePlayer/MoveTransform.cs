using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private readonly Rigidbody2D _rigidbodySpaceShip;
        private Vector2 _input;
        private float _offsetMove = 0.02f;

        public float Speed { get; protected set; }

        public MoveTransform(Rigidbody2D rigidbody2D, float speed)
        {
            _rigidbodySpaceShip = rigidbody2D;
            Speed = speed;
        }

        public void Move(Transform transform, bool isInput, float x, float y)
        {
            _input.x = x;
            _input.y = y;

            if (isInput == true)
            {
                _rigidbodySpaceShip.AddForce(_input * Speed);
            }
            else
            {
                _rigidbodySpaceShip.velocity = Vector2.Lerp(_rigidbodySpaceShip.velocity, Vector2.zero, _offsetMove);
            }
        }
    }
}
