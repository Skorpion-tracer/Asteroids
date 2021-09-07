using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Enemy : MonoBehaviour
    {
        public IEnemyFactory Factory;
        public Health Health { get; private set; }

        public ViewServices<Asteroid> ViewServicesAsteroids = new ViewServices<Asteroid>();
        public ViewServices<SpaceGarbage> ViewServicesSpaceGarbage = new ViewServices<SpaceGarbage>();

        public Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Resources.Load<Asteroid>("Enemy/Asteroid");
            enemy.Health = hp;
            enemy.transform.position = new Vector2(Random.Range(0, 2f), Random.Range(0, 4f));
            enemy = ViewServicesAsteroids.Instantiate(enemy);
            enemy.SetPool(ViewServicesAsteroids);
            return enemy;
        }

        public SpaceGarbage CreateSpaceGarbage(Health hp)
        {
            var enemy = Resources.Load<SpaceGarbage>("Enemy/SpaceGarbage");
            enemy.Health = hp;
            enemy.transform.position = new Vector2(Random.Range(0, 4f), Random.Range(0, 8f));
            enemy = ViewServicesSpaceGarbage.Instantiate(enemy);
            enemy.SetPool(ViewServicesSpaceGarbage);
            return enemy;
        }

        public void CreatePoolAsteroids(int count)
        {
            Asteroid asteroid = Resources.Load<Asteroid>("Enemy/Asteroid");
            asteroid.transform.position = Vector2.zero;
            asteroid.transform.rotation = Quaternion.identity;
            for (int i = 0; i < count; i++)
            {
                ViewServicesAsteroids.InstantiateNotActive(asteroid);
            }
        }

        public void CreatePoolSpaceGarbage(int count)
        {
            SpaceGarbage spaceGarbage = Resources.Load<SpaceGarbage>("Enemy/SpaceGarbage");
            spaceGarbage.transform.position = Vector2.zero;
            spaceGarbage.transform.rotation = Quaternion.identity;
            for (int i = 0; i < count; i++)
            {
                ViewServicesSpaceGarbage.InstantiateNotActive(spaceGarbage);
            }
        }

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        public abstract void Move(float speed, Transform transformTarget);

        public abstract void Destroy();
    }
}
