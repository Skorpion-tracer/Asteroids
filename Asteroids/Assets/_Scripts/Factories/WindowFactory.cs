using System;
using UnityEngine;

namespace Asteroids.Abstract_Factory
{
    public sealed class WindowFactory
    {
        public IWindow CreateWindow(RuntimePlatform platform)
        {
            switch(platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor:
                    return new PCWindow();
                case RuntimePlatform.XboxOne:
                case RuntimePlatform.PS5:
                    return new ConsoleWindow();
                default: throw new ArgumentOutOfRangeException(nameof(platform),
                platform, null);
            }
        }
    }
}