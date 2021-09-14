using UnityEngine;

namespace Asteroids
{
    public sealed class BoundScreen
    {
        public bool IsOnScreen = true;

        public float Radius = -4f;
        public float CameraWidth;
        public float CameraHeight;

        public BoundScreen()
        {
            CameraHeight = Camera.main.orthographicSize;
            CameraWidth = CameraHeight * Camera.main.aspect;
        }

        public void Execute(Vector2 position)
        {
            IsOnScreen = true;

            if (position.x > CameraWidth - Radius)
            {
                position.x = CameraWidth - Radius;
                IsOnScreen = false;
            }
            if (position.x < -CameraWidth + Radius)
            {
                position.x = -CameraWidth + Radius;
                IsOnScreen = false;
            }
            if (position.y > CameraHeight - Radius)
            {
                position.y = CameraHeight - Radius;
                IsOnScreen = false;
            }
            if (position.y < -CameraHeight + Radius)
            {
                position.y = -CameraHeight + Radius;
                IsOnScreen = false;
            }
        }
    }
}
