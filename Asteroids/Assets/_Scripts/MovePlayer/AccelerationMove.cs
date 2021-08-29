using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal sealed class AccelerationMove : MoveTransform
    {
        private readonly float _acceleration;

        public AccelerationMove(Rigidbody2D transform, float speed, float acceleration) : 
            base(transform, speed)
        {
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        {
            Speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}
