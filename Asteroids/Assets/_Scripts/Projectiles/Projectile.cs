using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour, IProjectile
    {        
        [SerializeField] protected float _force;
        [SerializeField] private int _damage = 10;

        public Rigidbody2D BodyBullet;

        protected Transform _positionBullet;
        protected BoundScreen _boundScreen;
        protected Queue<Blaster> _blasters = new Queue<Blaster>();

        private ViewServices<Blaster> _viewServices = new ViewServices<Blaster>();        

        public int Damage 
        { 
            get => _damage; 
            set => _damage = value; 
        }

        public Blaster CreateBlaster(GameObject prefab, Transform positionBullet)
        {    
            if (_boundScreen == null) _boundScreen = new BoundScreen();
            Blaster blaster = prefab.GetComponent<Blaster>();
            blaster = _viewServices.Instantiate(blaster, positionBullet);
            _positionBullet = positionBullet;
            blaster.SetPool(_viewServices);
            if (_blasters.Contains(blaster) == false)
            {
                _blasters.Enqueue(blaster);
            }
            blaster.SetBoundsScreen(_boundScreen);
            blaster.SetQueue(_blasters);
            return blaster;
        }

        public void CreatePoolBlasters(int count, GameObject prefab)
        {
            _boundScreen = new BoundScreen();
            Blaster blaster = prefab.GetComponent<Blaster>();
            blaster.transform.position = Vector2.zero;
            blaster.transform.rotation = Quaternion.identity;
            for (int i = 0; i < count; i++)
            {                
                _viewServices.InstantiateNotActive(blaster);
            }
        }

        public Queue<Blaster> Get()
        {
            return _blasters;
        }

        public abstract void Move();

        public abstract void Execute();

        public abstract void Destroy();

        public void SetBoundsScreen(BoundScreen boundScreen)
        {
            _boundScreen = boundScreen;
        }

        public void SetQueue(Queue<Blaster> blasters)
        {
            _blasters = blasters;
        }
    }
}
