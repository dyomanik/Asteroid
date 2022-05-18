using UnityEngine;
namespace Asteroid
{
    public interface IDamage
    {
        int healthPoints { get; }
        void Hit(GameObject gameObject);
    }
}