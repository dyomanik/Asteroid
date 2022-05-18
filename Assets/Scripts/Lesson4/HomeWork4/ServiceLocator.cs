using System;
using System.Collections.Generic;
namespace Asteroid.ServiceLocatore
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _service—ontainer = new Dictionary<Type, object>();
        public static void Register<T>(T value) where T : class
        {
            var typeValue = typeof(T);
            if (!_service—ontainer.ContainsKey(typeValue))
            {
                _service—ontainer[typeValue] = value;
            }
        }
        public static T GetService<T>()
        {
            var type = typeof(T);
            if (_service—ontainer.ContainsKey(type))
            {
                return (T)_service—ontainer[type];
            }
            return default;
        }

    }
}