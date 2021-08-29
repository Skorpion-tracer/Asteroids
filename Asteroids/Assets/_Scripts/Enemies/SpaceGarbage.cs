﻿using UnityEngine;

namespace Asteroids
{
    public sealed class SpaceGarbage : Enemy
    {
        public override void Move(float speed, Transform transformTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                transformTarget.position, speed * Time.deltaTime);
        }
    }
}
