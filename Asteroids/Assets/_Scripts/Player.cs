using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _rigidbodySpaceShip;
        [SerializeField] private Transform _barrel;
        [SerializeField] private GameObject _prefabBullet;

        private Camera _camera;
        private Ship _ship;
        private Projectile _projectile;

        private void Start()
        {
            _camera = Camera.main;

            var builderProjectile = new BuilderProjectile();

            _projectile = builderProjectile.
                          Prefab.
                          Prefab(_prefabBullet).
                          Physics.
                          Rigidbody2D(0.3f).
                          BoxCollider2D();
            _projectile.CreatePoolBlasters(20, _prefabBullet);
            
            var moveTransform = new AccelerationMove(_rigidbodySpaceShip, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            var shooter = new Shooter(_projectile);

            _ship = new Ship(moveTransform, rotation, shooter);
        }

        public void Execute()
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

            foreach (Blaster blaster in _projectile.Get())
            {
                if (blaster.gameObject.activeInHierarchy)
                {
                    blaster.Execute();
                }
            }
        }

        public void FixedExecute()
        {
            _ship.Move(Input.anyKey, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                float setRotationAfterCollison = 0f;
                _rigidbodySpaceShip.AddForce(enemy.gameObject.transform.up * enemy.ForceHit, ForceMode2D.Impulse);
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