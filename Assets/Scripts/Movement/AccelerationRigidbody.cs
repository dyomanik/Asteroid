using UnityEngine;
namespace Asteroid
{
    internal sealed class AccelerationRigidbody : RigidbodyMovement
    {
        private readonly float _acceleration;
        
        public AccelerationRigidbody(Rigidbody2D rigidbody, float speed, float acceleration) : base(rigidbody,speed)
        {
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        {
            Speed += _acceleration;
        }
        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}