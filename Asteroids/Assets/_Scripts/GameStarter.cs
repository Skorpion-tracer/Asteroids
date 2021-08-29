using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            IEnemyFactory factory = new AsteroidFactory();

            Enemy.Factory = factory;
            Enemy.Factory.CreateAsteroid(new Health(100.0f, 100.0f));            

            Enemy.CreateSpaceGarbage(new Health(10.0f, 10.0f));
            Enemy.Factory.CreateSpaceGarbage(new Health(43.0f, 32.0f));
        }
    }
}
