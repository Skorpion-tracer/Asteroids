using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    internal sealed class GamePullObjectsPool<T> : IDisposable 
        where T : MonoBehaviour
    {
        public readonly Stack<T> Stack = new Stack<T>();

        private readonly T _prefab;
        private readonly Transform _root;

        public GamePullObjectsPool(T prefab)
        {
            _prefab = prefab;
            _root = new GameObject($"[{_prefab.name}]").transform;
        }

        public T Pop()
        {
            T someObject;
            if (Stack.Count == 0)
            {
                someObject = Object.Instantiate(_prefab);
                someObject.name = _prefab.name;
            }
            else
            {
                someObject = Stack.Pop();
            }

            someObject.gameObject.SetActive(true);
            someObject.transform.SetParent(null);
            return someObject;
        }

        public void Push(T someObject)
        {
            Stack.Push(someObject);
            someObject.transform.SetParent(_root);
            someObject.gameObject.SetActive(false);
        }

        public void PopNotActive(T someObject)
        {
            someObject = Object.Instantiate(_prefab);
            someObject.name = _prefab.name;
            someObject.transform.SetParent(_root);
            someObject.gameObject.SetActive(false);
            Stack.Push(someObject);
        }

        public void Dispose()
        {
            for (int i = 0; i < Stack.Count; i++)
            {
                var gameObject = Stack.Pop();
                Object.Destroy(gameObject);
            }
            Object.Destroy(_root.gameObject);
        }
    }
}
