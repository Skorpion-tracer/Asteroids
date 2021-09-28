using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Decorator
{
    public class Aim : IAim
    {
        public GameObject AimInstance { get; }

        public Aim(GameObject aimInstance)
        {
            AimInstance = aimInstance;
        }
    }
}
