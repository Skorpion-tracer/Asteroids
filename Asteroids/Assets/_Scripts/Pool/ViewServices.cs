using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public sealed class ViewServices<T> 
        where T : MonoBehaviour
    {
        private readonly Dictionary<string, GamePullObjectsPool<T>> _viewCache =
            new Dictionary<string, GamePullObjectsPool<T>>(20);

        public T Instantiate(T prefab, Transform transform = null)
        {
            if (!_viewCache.TryGetValue(prefab.name, out GamePullObjectsPool<T> viewPool))
            {
                viewPool = new GamePullObjectsPool<T>(prefab);
                _viewCache[prefab.name] = viewPool;
            }

            return viewPool.Pop(transform);
        }

        public void InstantiateNotActive(T prefab)
        {
            if (!_viewCache.TryGetValue(prefab.name, out GamePullObjectsPool<T> viewPool))
            {
                viewPool = new GamePullObjectsPool<T>(prefab);
                _viewCache[prefab.name] = viewPool;
            }

            viewPool.PopNotActive(prefab);
        }

        public void Destroy(T value)
        {
            _viewCache[value.name].Push(value);
        }
    }
}
