using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour, IProjectile
    {        
        [SerializeField] protected float _force;
        [SerializeField] public Rigidbody2D _bodyBullet;

        protected Transform _positionBullet;
        protected ViewServices<Blaster> _viewServices = new ViewServices<Blaster>();

        public Blaster CreateBlaster(GameObject prefab, Transform positionBullet)
        {
            Blaster blaster = prefab.GetComponent<Blaster>();
            blaster = _viewServices.Instantiate(blaster, positionBullet);
            _positionBullet = positionBullet;
            blaster.SetPool(_viewServices);
            return blaster;
        }

        public void CreatePoolBlasters(int count, GameObject prefab)
        {
            Blaster blaster = prefab.GetComponent<Blaster>();
            blaster.transform.position = Vector2.zero;
            blaster.transform.rotation = Quaternion.identity;
            for (int i = 0; i < count; i++)
            {                
                _viewServices.InstantiateNotActive(blaster);
            }
        }

        public abstract void Move();
    }
}
