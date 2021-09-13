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
        [SerializeField] private GameObject _prefabBullet;
        private Camera _camera;
        private Ship _ship;
        private Enemy[] _enemies;
        private Projectile _projectile;

        private void Start()
        {
            _camera = Camera.main;            
            var moveTransform = new AccelerationMove(_rigidbodySpaceShip, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _projectile = _prefabBullet.GetComponent<Blaster>();
            _projectile.BodyBullet = _prefabBullet.GetComponent<Rigidbody2D>();
            var shooter = new Shooter(_projectile);
            _ship = new Ship(moveTransform, rotation, shooter);
            _enemies = GameObject.FindObjectsOfType<Enemy>();
            _projectile.CreatePoolBlasters(20, _prefabBullet);
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
                _ship.Shoot(_prefabBullet, _barrel);
            }

            foreach (Enemy enemy in _enemies)
            {
                enemy.Rotate(transform.position);
            }
        }

        private void FixedUpdate()
        {
            _ship.Move(Input.anyKey, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            foreach (Enemy enemy in _enemies)
            {
                enemy.Move(transform);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            float setRotationAfterCollison = 0f;
            if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                _rigidbodySpaceShip.AddForce(enemy.gameObject.transform.up * 2, ForceMode2D.Impulse);
                _rigidbodySpaceShip.MoveRotation(setRotationAfterCollison);
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
}