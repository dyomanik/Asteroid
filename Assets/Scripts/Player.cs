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
        [SerializeField] private float _bulletForce;
        [SerializeField] private int _healthPoints;
        private IDamage _damage;

        public IFire firing;
        public Ship ship;
        
        private void Start()
        {
            var moveRigidbody = new AccelerationRigidbody(_rigidbody, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            ship = new Ship(moveRigidbody, rotation);
            firing = new Ammunition(_barrel,_bulletForce);
            _damage = new Damage(_healthPoints);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponentInChildren<Enemy>())
            {
                _damage.Hit(gameObject);
            }
        }
    }
}