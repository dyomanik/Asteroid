using UnityEngine;
namespace Asteroid
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        public void ActiveBullet(Transform barrel, float bulletForce)
        {
            transform.position = barrel.position;
            transform.rotation = barrel.rotation;
            gameObject.SetActive(true);
            _rigidbody.isKinematic = true;
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(barrel.up * bulletForce);
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Enemy>())
            {
                gameObject.SetActive(false);
                collision.gameObject.SetActive(false);
            }
        }
    }
}