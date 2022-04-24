using UnityEngine;
namespace Asteroid
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [Range(1000f,1500f)]
        [SerializeField] private float _force;
        private IDamage _damage;
        
        public IFire firing;
        public Ship ship;
        
        private void Start()
        {
            var moveRigidbody = new AccelerationRigidbody(_rigidbody, _speed, _acceleration);
            var rotationRigidbody = new RotationShip(transform);
            ship = new Ship(moveRigidbody, rotationRigidbody);
            firing = new Fire(_bullet, _barrel, _force);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _damage.Hit(gameObject);
        }
    }
}