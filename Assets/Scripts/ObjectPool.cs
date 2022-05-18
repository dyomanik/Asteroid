using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
namespace Asteroid
{
    internal sealed class ObjectPool : IDisposable
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private readonly Transform _root;

        public ObjectPool(GameObject prefab)
        {
            _prefab = prefab;
            _root = new GameObject($"{_prefab.name} pool").transform;
        }

        public GameObject GetFromPool()
        {
            GameObject gameObject;
            if (_stack.Count == 0)
            {
                gameObject = Object.Instantiate(_prefab);
                gameObject.name = _prefab.name;
            }
            else
            {
                gameObject = _stack.Pop();
            }
            gameObject.SetActive(true);
            gameObject.transform.SetParent(null);
            return gameObject;
        }

        public void ReturnToPool(GameObject gameObject)
        {
            _stack.Push(gameObject);
            gameObject.transform.SetParent(_root);
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
            for (var i = 0; i < _stack.Count; i++)
            {
                var gameObject = _stack.Pop();
                Object.Destroy(gameObject);
            }
            Object.Destroy(_root.gameObject);
        }
    }
}