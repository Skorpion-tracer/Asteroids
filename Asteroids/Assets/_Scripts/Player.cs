using System.Collections.Generic;
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
        [SerializeField] private Transform _barrel;
        private Camera _camera;
        private Ship _ship;
        private Enemy[] _enemies;

        private Player() { }

        private static Player _instance;
        public static Player Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Player();
                }
                return _instance;
            }
        }

        private void Start()
        {
            _camera = Camera.main;            
            var moveTransform = new AccelerationMove(_rigidbodySpaceShip, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            var shooter = new Shooter(_barrel);
            _ship = new Ship(moveTransform, rotation, shooter);
            _enemies = GameObject.FindObjectsOfType<Enemy>();
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

            foreach (Enemy enemy in _enemies)
            {
                enemy.Move(Random.Range(1f, 5f), transform);
            }
        }

        private void FixedUpdate()
        {
            _ship.Move(Input.anyKey, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
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