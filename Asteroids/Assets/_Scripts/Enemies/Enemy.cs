using UnityEngine;

namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        public Health Health { get; private set; }

        private static ViewServices _viewServices = new ViewServices();

        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Resources.Load<Asteroid>("Enemy/Asteroid");
            enemy.Health = hp;
            _viewServices.Instantiate(enemy);
            return enemy;
        }

        public static SpaceGarbage CreateSpaceGarbage(Health hp)
        {
            var enemy = Resources.Load<SpaceGarbage>("Enemy/SpaceGarbage");
            enemy.Health = hp;
            enemy.transform.position = new Vector2(Random.Range(0, 2f), Random.Range(0, 4f));            
            _viewServices.Instantiate(enemy);
            return enemy;
        }

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        public abstract void Move(float speed, Transform transformTarget);
    }
}
