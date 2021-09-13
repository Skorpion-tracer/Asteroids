using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] protected float _speed;

        public IEnemyFactory Factory;
        public Health Health { get; protected set; }

        public ViewServices<Asteroid> ViewServicesAsteroids = new ViewServices<Asteroid>();
        public ViewServices<SpaceGarbage> ViewServicesSpaceGarbage = new ViewServices<SpaceGarbage>();

        protected BoundScreen _boundScreen;
        protected Rigidbody2D _bodyEnemy;

        protected virtual void Awake()
        {
            _boundScreen = new BoundScreen();
            _bodyEnemy = GetComponent<Rigidbody2D>();
        }

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        public abstract Enemy CreateEnemy(Health hp);

        public abstract void CreatePool(int count);

        public abstract void Move(Transform transformTarget);

        public abstract void Rotate(Vector3 direction);

        public abstract void Destroy();

        protected abstract void SpawnEnemy(Enemy go);
    }
}
