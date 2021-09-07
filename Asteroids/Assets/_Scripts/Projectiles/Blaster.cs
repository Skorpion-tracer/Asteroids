using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Blaster : Projectile
    {
        private ViewServices<Blaster> _viewServices;
        public override void Move()
        {
            _bodyBullet.AddForce(transform.up * _force);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.gameObject.name);
            _viewServices.Destroy(this);
        }

        public void SetPool(ViewServices<Blaster> viewServices)
        {
            _viewServices = viewServices;
        }
    }
}
