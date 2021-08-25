using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _rigidbodySpaceShip;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        private Camera _camera;
        private Ship _ship;

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(_rigidbodySpaceShip, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            var shoter = new Shooter(_bullet, _barrel, _force);
            _ship = new Ship(moveTransform, rotation, shoter);
        }

        private void Update()
        {
            var direction = Input.mousePosition -
                _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _ship.Shoot();
            }
        }

        private void FixedUpdate()
        {
            _ship.Move(transform, Input.anyKey, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }
    }
}