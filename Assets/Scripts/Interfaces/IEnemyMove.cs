using UnityEngine;
namespace Asteroid
{
    public interface IEnemyMove
    {
       float Speed { get; }

       void Move(Vector3 playerPosition);
    }
}