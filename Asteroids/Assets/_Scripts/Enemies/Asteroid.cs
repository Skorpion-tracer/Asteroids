using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : Enemy
    {
        private ViewServices<Asteroid> _viewServices;

        private Queue<Asteroid> _queueEnemy = new Queue<Asteroid>();

        public override void Move()
        {
            if (gameObject.activeInHierarchy)
            {
                _bodyEnemy.velocity = transform.up * _speed;

                _boundScreen.Execute(transform.position);
                if (_boundScreen.IsOnScreen == false)
                {
                    Destroy();
                }
            }
        }

        public override void Rotate(Vector3 direction)
        {
            var thisDirection = direction - transform.position;
            var angle = Mathf.Atan2(thisDirection.y, thisDirection.x) * Mathf.Rad2Deg - 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _speed * Time.deltaTime);
        }

        public override Enemy CreateEnemy(Health hp)
        {
            var enemy = Resources.Load<Asteroid>("Enemy/Asteroid");
            enemy = ViewServicesAsteroids.Instantiate(enemy);
            enemy.Health = hp;
            SpawnEnemy(enemy);
            enemy.SetPool(ViewServicesAsteroids);
            _queueEnemy.Enqueue(enemy);
            return enemy;
        }

        public Queue<Asteroid> Get()
        {
            return _queueEnemy;
        }

        public override void CreatePool(int count)
        {
            _boundScreen = new BoundScreen();
            Asteroid asteroid = Resources.Load<Asteroid>("Enemy/Asteroid");
            asteroid.transform.position = Vector2.zero;
            asteroid.transform.rotation = Quaternion.identity;
            for (int i = 0; i < count; i++)
            {
                ViewServicesAsteroids.InstantiateNotActive(asteroid);
            }
            asteroid.SetPool(ViewServicesAsteroids);
        }
        public void SetPool(ViewServices<Asteroid> viewServices)
        {
            _viewServices = viewServices;
        }

        public override void Destroy()
        {
            if (_queueEnemy.Count != 0)
            {
                _queueEnemy.Dequeue();
            }
            _viewServices.Destroy(this);
        }

        protected override void SpawnEnemy(Enemy gameObject)
        {
            float enemyPadding = Mathf.Abs(_boundScreen.Radius);
            float heightOffset = 1.0f;

            Vector2 position = Vector2.zero;
            float minX = -_boundScreen.CameraWidth + enemyPadding;
            float maxX = _boundScreen.CameraWidth - enemyPadding;
            position.x = Random.Range(minX, maxX);
            position.y = _boundScreen.CameraHeight + heightOffset;
            gameObject.transform.position = position;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<IProjectile>(out IProjectile projectile))
            {
                Health.Current -= projectile.Damage;
                if (Health.Current <= 0)
                {
                    Destroy();
                }
            }
            if (collision.gameObject.TryGetComponent<Player>(out _))
            {
                Destroy();
            }
        }
    }
}
