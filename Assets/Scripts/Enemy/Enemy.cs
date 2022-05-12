using UnityEngine;
namespace Asteroid
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal abstract class Enemy : MonoBehaviour
    {
        private static readonly float _minScale = 0.3f;
        private static readonly float _maxScale = 0.6f;
        private static readonly float _minAngle = 0f;
        private static readonly float _maxAngle = 359.0f;
        private float randomRotation;
        
        [SerializeField][Range(0.5f,1f)]
        private float _speed;
        private Rigidbody2D _rigidbody;
        private Player _player;
        private Transform _rootPool;
        private Health _health;
        private IEnemyMove _enemyMove;

        public static IEnemyFactory Factory;
        public Health Health
        {
            get
            {
                if (_health.Current <= 0.0f)
                {
                    ReturnToPool();
                }
                return _health;
            }
            protected set => _health = value;
        }
        
        public static Asteroids CreateAsteroidEnemy(Health healthPoints)
        {
            var enemy = Instantiate(Resources.Load<Asteroids>("Enemy/Asteroid"));
            enemy.Health = healthPoints;
            return enemy;
        }

        public static Satelite CreateSateliteEnemy(Health healthPoints)
        {
            var enemy = Instantiate(Resources.Load<Satelite>("Enemy/Satelite"));
            var randomRotation = Random.Range(_minAngle, _maxAngle);
            var randomScale = Random.Range(_minScale, _maxScale);
            enemy.transform.rotation = Quaternion.AngleAxis(randomRotation, Vector3.forward);
            enemy.transform.localScale = new Vector3(randomScale, randomScale);
            enemy.Health = healthPoints;
            return enemy;
        }

        public void DependencyInjectHealth(Health healthPoints)
        {
            Health = healthPoints;
        }

        public Transform RootPool
        {
            get
            {
                if( _rootPool == null)
                {
                    var find = GameObject.Find(NameConstants.POOL_ENEMIES);
                    _rootPool = find == null ? null : find.transform;
                }
                return _rootPool;
            }
        }

        public void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = Quaternion.AngleAxis(randomRotation, Vector3.forward);
            gameObject.SetActive(true);
            //transform.SetParent(RootPool);
            _enemyMove.Move(_player.transform.position);
        }

        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RootPool);

            if (!RootPool)
            {
                Destroy(gameObject);
            }
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _enemyMove = new EnemyMove(_rigidbody, _speed);
            _player = FindObjectOfType<Player>();
            randomRotation = Random.Range(_minAngle, _maxAngle);
        }

        private void Update()
        {
            if (_player.transform.position == _player.transform.position)
            {
                _player.transform.position = _player.transform.position;
            }
        }

    }
}