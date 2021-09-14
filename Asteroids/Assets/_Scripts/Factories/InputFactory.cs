using System;
using UnityEngine;

namespace Asteroids.Abstract_Factory
{
    public sealed class InputFactory
    {
        public IInput CreateInput(RuntimePlatform platform)
        {
            switch(platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor:
                    return new PCInput();
                case RuntimePlatform.XboxOne:
                case RuntimePlatform.PS5:
                    return new ConsoleInput();
                default: throw new ArgumentOutOfRangeException(nameof(platform),
                platform, null);
            }
        }
    }
}
