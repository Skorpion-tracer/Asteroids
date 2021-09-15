using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class SpaceGarbage : Enemy
    {
        private ViewServices<SpaceGarbage> _viewServices;

        private Queue<SpaceGarbage> _queueEnemy = new Queue<SpaceGarbage>();

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
            var enemy = Resources.Load<SpaceGarbage>("Enemy/SpaceGarbage"); 
            enemy = ViewServicesSpaceGarbage.Instantiate(enemy);
            enemy.Health = hp;
            SpawnEnemy(enemy);
            enemy.SetPool(ViewServicesSpaceGarbage);
            _queueEnemy.Enqueue(enemy);
            return enemy;
        }

        public Queue<SpaceGarbage> Get()
        {
            return _queueEnemy;
        }

        public override void CreatePool(int count)
        {
            _boundScreen = new BoundScreen();
            SpaceGarbage spaceGarbage = Resources.Load<SpaceGarbage>("Enemy/SpaceGarbage");
            spaceGarbage.transform.position = Vector2.zero;
            spaceGarbage.transform.rotation = Quaternion.identity;
            for (int i = 0; i < count; i++)
            {
                ViewServicesSpaceGarbage.InstantiateNotActive(spaceGarbage);
            }
            spaceGarbage.SetPool(ViewServicesSpaceGarbage);
        }

        public void SetPool(ViewServices<SpaceGarbage> viewServices)
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
            float heightOffset = 3.0f;

            Vector2 position = Vector2.zero;
            float minX = -_boundScreen.CameraWidth + enemyPadding;
            float maxX = _boundScreen.CameraWidth - enemyPadding;
            position.x = Random.Range(minX, maxX);
            position.y = _boundScreen.CameraHeight - heightOffset;
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
