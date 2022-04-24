using UnityEngine;
namespace Asteroid
{
    public interface IDamage
    {
        float healthPoints { get; }
        void Hit(GameObject gameObject);
    }
}