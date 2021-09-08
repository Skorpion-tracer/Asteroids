using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabAsteroid;
        [SerializeField] private GameObject _prefabSpaceGarbage;

        private Enemy _asteroid;
        private Enemy _spaceGarbage;

        private void Start()
        {
            _asteroid = _prefabAsteroid.GetComponent<Asteroid>();
            _spaceGarbage = _prefabSpaceGarbage.GetComponent<SpaceGarbage>();

            _asteroid.CreatePool(5);
            _asteroid.CreateEnemy(new Health(100.0f, 100.0f));
            _asteroid.CreateEnemy(new Health(100.0f, 100.0f));
            _asteroid.CreateEnemy(new Health(100.0f, 100.0f));

            _spaceGarbage.CreatePool(10);
            _spaceGarbage.CreateEnemy(new Health(43.0f, 32.0f));
            _spaceGarbage.CreateEnemy(new Health(43.0f, 32.0f));
            _spaceGarbage.CreateEnemy(new Health(43.0f, 32.0f));
            _spaceGarbage.CreateEnemy(new Health(43.0f, 32.0f));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                _spaceGarbage.CreateEnemy(new Health(43, 43));
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                _asteroid.CreateEnemy(new Health(43, 43));
            }
        }
    }
}
