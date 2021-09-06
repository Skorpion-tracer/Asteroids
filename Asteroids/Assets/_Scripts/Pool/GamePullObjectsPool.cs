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
        private readonly Stack<T> _stack = new Stack<T>();
        private readonly T _prefab;
        private readonly Transform _root;

        public GamePullObjectsPool(T prefab)
        {
            _prefab = prefab;
            _root = new GameObject($"[{_prefab.name}]").transform;
        }

        public T Pop(Transform transform = null)
        {
            T someObject;
            if (_stack.Count == 0)
            {
                someObject = Object.Instantiate(_prefab);
                someObject.name = _prefab.name;
            }
            else
            {
                someObject = _stack.Pop();
            }

            someObject.gameObject.SetActive(true);
            
            if (transform != null)
            {
                someObject.transform.position = transform.position;
                someObject.transform.rotation = transform.rotation;
            }
            someObject.transform.SetParent(null);

            return someObject;
        }

        public void Push(T someObject)
        {
            _stack.Push(someObject);
            someObject.transform.SetParent(_root);
            someObject.gameObject.SetActive(false);
        }

        public void PopNotActive(T someObject)
        {
            someObject = Object.Instantiate(_prefab);
            someObject.name = _prefab.name;
            someObject.transform.SetParent(_root);
            someObject.gameObject.SetActive(false);
            _stack.Push(someObject);
        }

        public void Dispose()
        {
            for (int i = 0; i < _stack.Count; i++)
            {
                var gameObject = _stack.Pop();
                Object.Destroy(gameObject);
            }
            Object.Destroy(_root.gameObject);
        }
    }
}
