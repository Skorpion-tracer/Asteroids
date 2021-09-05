using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour
    {        
        [SerializeField] protected float _force;

        protected static Transform _positionBullet;
        protected static Rigidbody2D _bodyBullet;

        protected static ViewServices<Blaster> _viewServices
            = new ViewServices<Blaster>();

        public static Blaster CreateBlaster(Transform positionBullet)
        {
            _positionBullet = positionBullet;
            var blaster = Resources.Load<Blaster>("Projectiles/Blaster");
            blaster.transform.position = _positionBullet.position;
            blaster.transform.rotation = _positionBullet.rotation;
            _bodyBullet = blaster.gameObject.GetComponent<Rigidbody2D>();
            _viewServices.Instantiate(blaster);
            return blaster;
        }

        public static void CreatePoolBlasters(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var blaster = Resources.Load<Blaster>("Projectiles/Blaster");
                _viewServices.InstantiateNotActive(blaster);
            }
        }

        public abstract void Move();
    }
}
