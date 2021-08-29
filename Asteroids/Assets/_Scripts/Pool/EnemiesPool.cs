using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    internal sealed class EnemiesPool : IDisposable
    {
        private readonly Stack<Enemy> _stack = new Stack<Enemy>();
        private readonly Enemy _prefab;
        private readonly Transform _root;

        public EnemiesPool(Enemy prefab)
        {
            _prefab = prefab;
            _root = new GameObject($"[{_prefab.name}]").transform;
        }

        public Enemy Pop()
        {
            Enemy enemy;
            if (_stack.Count == 0)
            {
                enemy = Object.Instantiate(_prefab);
                enemy.name = _prefab.name;
            }
            else
            {
                enemy = _stack.Pop();
            }

            enemy.transform.SetParent(_root);
            return enemy;
        }

        public void Push(Enemy enemy)
        {
            _stack.Push(enemy);
            enemy.transform.SetParent(_root);
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
