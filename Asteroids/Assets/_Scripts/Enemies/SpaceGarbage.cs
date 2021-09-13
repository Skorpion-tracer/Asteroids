using UnityEngine;

namespace Asteroids
{
    public sealed class SpaceGarbage : Enemy
    {
        private ViewServices<SpaceGarbage> _viewServices;

        public override void Move(Transform transformTarget)
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
            enemy.transform.position = new Vector2(Random.Range(0, 2f), Random.Range(0, 4f));
            enemy.Health = hp;
            enemy.SetPool(ViewServicesSpaceGarbage);
            return enemy;
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
        }

        public void SetPool(ViewServices<SpaceGarbage> viewServices)
        {
            _viewServices = viewServices;
        }

        public override void Destroy()
        {
            _viewServices.Destroy(this);
        }

        protected override void SpawnEnemy(Enemy gameObject)
        {
            throw new System.NotImplementedException();
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
