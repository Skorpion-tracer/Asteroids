using UnityEngine;

namespace Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy CreateAsteroid(Health hp)
        {
            var enemy = Resources.Load<Asteroid>("Enemy/Asteroid");
            enemy.DependencyInjectHealth(hp);
            enemy.transform.position = new Vector2(Random.Range(0, 2f), Random.Range(0, 4f));
            Enemy.ViewServices.Instantiate(enemy);
            return enemy;
        }

        public Enemy CreateSpaceGarbage(Health hp)
        {
            var enemy = Resources.Load<SpaceGarbage>("Enemy/SpaceGarbage");
            enemy.DependencyInjectHealth(hp);
            enemy.transform.position = new Vector2(Random.Range(0, 2f), Random.Range(0, 4f));
            Enemy.ViewServices.Instantiate(enemy);
            return enemy;
        }
    }
}
