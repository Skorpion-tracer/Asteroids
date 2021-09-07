using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabAsteroid;
        [SerializeField] private GameObject _prefabSpaceGarbage;

        private Asteroid _asteroid;
        private SpaceGarbage _spaceGarbage;

        private void Start()
        {
            _asteroid = _prefabAsteroid.GetComponent<Asteroid>();
            _spaceGarbage = _prefabSpaceGarbage.GetComponent<SpaceGarbage>();
            IEnemyFactory factory = new AsteroidFactory();

            _asteroid.Factory = factory;
            _asteroid.CreatePoolAsteroids(5);
            _asteroid.CreateAsteroidEnemy(new Health(100.0f, 100.0f));


            _spaceGarbage.Factory = factory;
            _spaceGarbage.CreatePoolSpaceGarbage(10);
            _spaceGarbage.CreateSpaceGarbage(new Health(43.0f, 32.0f));
            _spaceGarbage.CreateSpaceGarbage(new Health(43.0f, 32.0f));
            _spaceGarbage.CreateSpaceGarbage(new Health(43.0f, 32.0f));
            _spaceGarbage.CreateSpaceGarbage(new Health(43.0f, 32.0f));            
        }
    }
}
