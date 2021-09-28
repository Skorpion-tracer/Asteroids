using System;
using UnityEngine;

namespace Asteroids
{
    public class Interceptor : MonoBehaviour, IEnemy
    {
        private IMotion _motion;
        private IAttack _attack;
        private Health _heath;

        public Transform PositionProjectile;

        public void Move(Transform transform, Transform playerPosition, float speed)
        {
            _motion.Move(transform, playerPosition, speed);
        }

        public void Attack()
        {
            _attack.Attack();
        }

        public void SetReference(IMotion motion, IAttack attack, Health health)
        {
            _motion = motion;
            _attack = attack;
            _attack.PositionSpawn = PositionProjectile;
            _heath = health;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<IProjectile>(out IProjectile projectile))
            {
                _heath.Current -= projectile.Damage;
                if (_heath.Current <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
            if (collision.gameObject.TryGetComponent<Player>(out _))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
