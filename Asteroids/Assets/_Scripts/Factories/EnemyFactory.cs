using UnityEngine;

namespace Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        private ViewServices viewServices = new ViewServices();
        public Enemy CreateAsteroid(Health hp)
        {
            var enemy = Resources.Load<Asteroid>("Enemy/Asteroid");
            enemy.DependencyInjectHealth(hp);
            viewServices.Instantiate(enemy);
            return enemy;
        }

        public Enemy CreateSpaceGarbage(Health hp)
        {
            var enemy = Resources.Load<SpaceGarbage>("Enemy/SpaceGarbage");
            enemy.DependencyInjectHealth(hp);
            enemy.transform.position = new Vector2(Random.Range(0, 2f), Random.Range(0, 4f));
            viewServices.Instantiate(enemy);
            return enemy;
        }
    }
}
