using UnityEngine;

namespace Asteroids
{
    public sealed class RotationShip : IRotation
    {
        private readonly Transform _transform;
        private readonly float _offset = 90.0f;
        private readonly float _speedRotation = 8;

        public RotationShip(Transform transform)
        {
            _transform = transform;
        }

        public void Rotation(Vector2 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - _offset;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _transform.transform.rotation = Quaternion.Slerp(_transform.transform.rotation, rotation, _speedRotation * Time.deltaTime);
        }
    }
}
