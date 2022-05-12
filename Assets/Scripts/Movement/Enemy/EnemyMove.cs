using UnityEngine;
namespace Asteroid
{
    internal sealed class EnemyMove : IEnemyMove
    {
        private readonly Rigidbody2D _rigidbody;
        private Vector3 _direction;
        private readonly float _offset = 6;
        public float Speed { get; set; }

        public EnemyMove(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            Speed = speed;
        }

        public void Move(Vector3 playerPosition)
        {
            _direction = playerPosition - _rigidbody.gameObject.transform.position + new Vector3(Random.Range(-_offset, _offset), Random.Range(-_offset, _offset));
            _rigidbody.AddForce(_direction*Speed,ForceMode2D.Impulse);
        }
    }
}