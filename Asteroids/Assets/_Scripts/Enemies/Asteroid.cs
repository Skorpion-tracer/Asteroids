using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : Enemy
    {
        private ViewServices<Asteroid> _viewServices;

        public override void Move(Transform transformTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                transformTarget.position, _speed * Time.deltaTime);

            _boundScreen.Execute(transform.position);
            if (_boundScreen.IsOnScreen == false)
            {
                Destroy();
            }
        }

        public override Enemy CreateEnemy(Health hp)
        {
            var enemy = Resources.Load<Asteroid>("Enemy/Asteroid");
            enemy = ViewServicesAsteroids.Instantiate(enemy);
            enemy.Health = hp;
            SpawnEnemy(enemy);
            enemy.SetPool(ViewServicesAsteroids);
            return enemy;
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
        }

        public void SetPool(ViewServices<Asteroid> viewServices)
        {
            _viewServices = viewServices;
        }

        public override void Destroy()
        {
            _viewServices.Destroy(this);
        }

        protected override void SpawnEnemy(Enemy gameObject)
        {
            float enemyPadding = Mathf.Abs(_boundScreen.Radius);

            Vector2 position = Vector2.zero;
            float minX = -_boundScreen.CameraWidth + enemyPadding;
            float maxX = _boundScreen.CameraWidth - enemyPadding;
            position.x = Random.Range(minX, maxX);
            position.y = _boundScreen.CameraHeight + enemyPadding;
            gameObject.transform.position = position;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<IProjectile>(out _))
            {
                Health.Current -= 10;
                if (Health.Current <= 0)
                {
                    Destroy();
                }
            }
        }
    }
}
