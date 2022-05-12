using UnityEngine;
namespace Asteroid
{
    public interface ICreate
    {
        T Instantiate<T>(GameObject prefab);

        void Destroy(GameObject value);
    }
}