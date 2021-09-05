using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        public Health Health { get; private set; }

        public static ViewServices<Enemy> ViewServices = new ViewServices<Enemy>();

        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Resources.Load<Asteroid>("Enemy/Asteroid");
            enemy.Health = hp;
            enemy.transform.position = new Vector2(Random.Range(0, 2f), Random.Range(0, 4f));
            ViewServices.Instantiate(enemy);
            return enemy;
        }

        public static SpaceGarbage CreateSpaceGarbage(Health hp)
        {
            var enemy = Resources.Load<SpaceGarbage>("Enemy/SpaceGarbage");
            enemy.Health = hp;
            enemy.transform.position = new Vector2(Random.Range(0, 2f), Random.Range(0, 4f));            
            ViewServices.Instantiate(enemy);
            return enemy;
        }

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        public abstract void Move(float speed, Transform transformTarget);

        public abstract void Destroy();
    }
}
