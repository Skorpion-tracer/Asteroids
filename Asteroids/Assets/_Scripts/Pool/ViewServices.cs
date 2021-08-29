using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public sealed class ViewServices
    {
        private readonly Dictionary<string, EnemiesPool> _viewCache =
            new Dictionary<string, EnemiesPool>(12);

        public void Instantiate(Enemy prefab)
        {
            if (!_viewCache.TryGetValue(prefab.name, out EnemiesPool viewPool))
            {
                viewPool = new EnemiesPool(prefab);
                _viewCache[prefab.name] = viewPool;
            }

            viewPool.Pop();
        }

        public void Destroy(Enemy value)
        {
            _viewCache[value.name].Push(value);
        }
    }
}
