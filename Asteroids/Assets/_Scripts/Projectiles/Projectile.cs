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

        public static Blaster CreateBlaster(GameObject prefab, Transform positionBullet)
        {
            Blaster blaster = prefab.GetComponent<Blaster>();
            _viewServices.Instantiate(blaster, positionBullet);
            _positionBullet = positionBullet;                       
            _bodyBullet = blaster.gameObject.GetComponent<Rigidbody2D>();
            return blaster;
        }

        public static void CreatePoolBlasters(int count, GameObject prefab)
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
