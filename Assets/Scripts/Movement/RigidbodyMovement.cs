using UnityEngine;
namespace Asteroid
{
    internal class RigidbodyMovement : IMove
    {
        private Vector2 _move;
        private readonly Rigidbody2D _rigidBody;
       
        public float Speed { get; protected set; }
        
        public RigidbodyMovement(Rigidbody2D rigidbody,float speed)
        {
            _rigidBody = rigidbody;
            Speed = speed;
        }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _move.Set(horizontal*Speed, vertical*Speed);
            _rigidBody.AddForce(_move);
        }
    }
}