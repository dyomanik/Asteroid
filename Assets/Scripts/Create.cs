using UnityEngine;
using System;
using System.Collections.Generic;
namespace Asteroid
{
    public class Create : ICreate
    {
        private readonly Dictionary<string, ObjectPool> _cache = new Dictionary<string, ObjectPool>(5);

        public T Instantiate<T>(GameObject prefab)
        {
            if(!_cache.TryGetValue(prefab.name, out ObjectPool pool))
            {
                pool = new ObjectPool(prefab);
                _cache[prefab.name] = pool;
            }

            if (pool.GetFromPool().TryGetComponent(out T component))
            {
                return component;
            }

            throw new InvalidOperationException($"{typeof(T)} not found");
        }

        public void Destroy(GameObject value)
        {
            _cache[value.name].ReturnToPool(value);
        }
    }
}