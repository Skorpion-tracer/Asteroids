using UnityEngine;

namespace Asteroids
{
    public sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabAsteroid;
        [SerializeField] private GameObject _prefabSpaceGarbage;
        [SerializeField] private GameObject _player;

        private Asteroid _asteroid;
        private SpaceGarbage _spaceGarbage;
        private Player _playerShip;

        private float _timer;
        private float _timerLimit = 5.0f;

        private void Start()
        {
            _asteroid = _prefabAsteroid.GetComponent<Asteroid>();
            _spaceGarbage = _prefabSpaceGarbage.GetComponent<SpaceGarbage>();
            
            _playerShip = _player.GetComponent<Player>();

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
            _playerShip.Execute();

            foreach (Asteroid asteroid in _asteroid.Get())
            {                
                if (asteroid.gameObject.activeInHierarchy)
                {
                    asteroid.Rotate(_playerShip.transform.position);
                }
            }

            foreach (SpaceGarbage spaceGarbage in _spaceGarbage.Get())
            {                
                if (spaceGarbage.gameObject.activeInHierarchy)
                {
                    spaceGarbage.Rotate(_playerShip.transform.position);
                }
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                _spaceGarbage.CreateEnemy(new Health(43, 43));
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                _asteroid.CreateEnemy(new Health(43, 43));
            }

            _timer += Time.deltaTime;
            if (_timer >= _timerLimit)
            {
                var asteroid = _asteroid.Clone();
                asteroid.CreateEnemy(new Health(100.0f, 100.0f));
                asteroid.Move();
                asteroid.Rotate(_playerShip.transform.position);
                _timer = 0;
            }
        }

        private void FixedUpdate()
        {
            _playerShip.FixedExecute();

            foreach (Asteroid asteroid in _asteroid.Get())
            {
                if (asteroid.gameObject.activeInHierarchy)
                {
                    asteroid.Move();
                }
            }

            foreach (SpaceGarbage spaceGarbage in _spaceGarbage.Get())
            {
                if (spaceGarbage.gameObject.activeInHierarchy)
                {
                    spaceGarbage.Move();
                }
            }
        }
    }
}
