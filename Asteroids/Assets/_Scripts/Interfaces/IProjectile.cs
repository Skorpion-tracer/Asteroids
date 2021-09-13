using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public interface IProjectile
    {
        int Damage { get; set; }
        Blaster CreateBlaster(GameObject prefab, Transform positionPrefab);
    }
}
