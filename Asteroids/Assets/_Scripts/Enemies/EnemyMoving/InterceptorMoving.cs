using UnityEngine;

namespace Asteroids
{
    public class InterceptorMoving : IMotion
    {
        private float _stoppingDistance = 10;
        private float _retreatDistance = 5;

        public void Move(Transform enemy, Transform player, float speed)
        {
            if (Vector2.Distance(enemy.position,
                    player.position) > _stoppingDistance)
            {
                enemy.position =
                    Vector2.MoveTowards(enemy.position,
                    player.position,
                    speed * Time.deltaTime);
            }
            else if (Vector2.Distance(enemy.position,
                player.position) < _stoppingDistance &&
                Vector2.Distance(enemy.position,
                player.position) > _retreatDistance)
            {
                enemy.position = enemy.position;
            }
            else if (Vector2.Distance(enemy.position,
                player.position) < _retreatDistance)
            {
                enemy.position = 
                    Vector2.MoveTowards(enemy.position, 
                    player.position, 
                    -speed * Time.deltaTime);
            }

            Rotate(player.position, enemy, speed);
        }

        public void Rotate(Vector3 direction, Transform enemy, float speed)
        {
            var thisDirection = direction - enemy.position;
            var angle = Mathf.Atan2(thisDirection.y, thisDirection.x) * Mathf.Rad2Deg - 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            enemy.rotation = Quaternion.Slerp(enemy.rotation, rotation, speed * Time.deltaTime);
        }
    }
}
