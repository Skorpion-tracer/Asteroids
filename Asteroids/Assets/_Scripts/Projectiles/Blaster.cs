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
        public override void Move()
        {
            _bodyBullet.AddForce(transform.up * _force);
        }
    }
}
