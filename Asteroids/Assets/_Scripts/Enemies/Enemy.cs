using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float _speed;

        public IEnemyFactory Factory;
        public Health Health { get; protected set; }

        public ViewServices<Asteroid> ViewServicesAsteroids = new ViewServices<Asteroid>();
        public ViewServices<SpaceGarbage> ViewServicesSpaceGarbage = new ViewServices<SpaceGarbage>();

        protected BoundScreen _boundScreen;

        protected virtual void Awake()
        {
            _boundScreen = new BoundScreen();
        }

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        public abstract Enemy CreateEnemy(Health hp);

        public abstract void CreatePool(int count);

        public abstract void Move(Transform transformTarget);

        public abstract void Destroy();

        protected abstract void SpawnEnemy(Enemy go);
    }
}
