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
            BodyBullet.velocity = transform.up * _force;
        }

        private void Start()
        {
            _boundScreen = new BoundScreen();
        }

        private void Update()
        {
            Execute();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            BodyBullet.velocity = Vector2.zero;
            BodyBullet.AddForce(Vector2.zero);
            _viewServices.Destroy(this);
        }

        public void SetPool(ViewServices<Blaster> viewServices)
        {
            _viewServices = viewServices;
        }

        public override void Execute()
        {
            _boundScreen.Execute(transform.position);
            if (_boundScreen.IsOnScreen == false)
            {
                _viewServices.Destroy(this);
            }
        }
    }
}
